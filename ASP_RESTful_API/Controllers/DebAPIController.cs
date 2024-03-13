using ASP_BasicAPI.Data;
using ASP_BasicAPI.Models;
using ASP_BasicAPI.Models.DTO;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP_BasicAPI.Controllers
{
    //[Route("api/[Controller]")
    [Route("api/DebAPI")]
    [ApiController]
    public class DebAPIController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public DebAPIController(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<PersonDTO>> GetPersons()
        {
            //ActionResult we can return any type of returntype
            return Ok(_db.Persons.ToList());
        }

        [HttpGet("{id:int}", Name = "GetPerson")] // Mention that you required ID
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(200, Type = typeof(PersonDTO))]
        //[ProducesResponseType(200)]
        public ActionResult<PersonDTO> GetPerson(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var person = _db.Persons.FirstOrDefault(u => u.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<PersonDTO> CreatePerson([FromBody] PersonDTO personDTO)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            if (_db.Persons.FirstOrDefault(u => u.Name.ToLower() == personDTO.Name.ToLower()) != null)
            {
                ModelState.AddModelError("Custom Error", "Person already exists!");
                return BadRequest(ModelState);
            }
            if (personDTO == null)
            {
                return BadRequest(personDTO);
            }

            if (personDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            Person model = new()
            {
                Id = personDTO.Id,
                Name = personDTO.Name,
                Gender = personDTO.Gender,
                Age = personDTO.Age,
                Details = personDTO.Details,
                Salary = personDTO.Salary,
                ImageUrl = personDTO.ImageUrl,
                Occupation = personDTO.Occupation,
                CreatedDate = DateTime.Now
            };
         
            _db.Persons.Add(model);
            _db.SaveChanges();

            //return Ok(personDTO);
            return CreatedAtRoute("GetPerson", new { id = personDTO.Id }, personDTO);
        }

        [HttpDelete("{id:int}", Name = "DeletePerson")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //IActionResult not need to define return type.
        public IActionResult DeletePerson(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var person = _db.Persons.FirstOrDefault(u => u.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            _db.Persons.Remove(person);
            _db.SaveChanges();
            return NoContent();
        }

        // To Remove all || This will clear all elements from the personList.
        //[HttpDelete]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public ActionResult DeletePersons()
        //{  
        //    PersonsData.personList.Clear();
        //    return NoContent();
        //}

        [HttpPut("{id:int}", Name = "UpdatePerson")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePerson(int id,[FromBody] PersonDTO personDTO)
        {
            if(personDTO == null || id != personDTO.Id)
            {
                return BadRequest();
            }
            //var person = PersonsData.personList.FirstOrDefault(u => u.Id == id);
            //person.Name = personDTO.Name;
            //person.Gender = personDTO.Gender;
            //person.Age = personDTO.Age;

            var person = _db.Persons.FirstOrDefault(u => u.Id == id);

            if (person == null)
            {
                return NotFound();
            }

            // Map properties from PersonDTO to Person
            person.Name = personDTO.Name;
            person.Gender = personDTO.Gender;
            person.Age = personDTO.Age;
            person.Details = personDTO.Details;
            person.Salary = personDTO.Salary;
            person.ImageUrl = personDTO.ImageUrl;
            person.Occupation = personDTO.Occupation;
            person.UpdatedDate = DateTime.Now;

            _db.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id:int}", Name = "UpdatePartialPerson")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePartialPerson(int id, JsonPatchDocument<PersonDTO> patchDTO)
        {
            if (patchDTO == null || id == 0)
            {
                return BadRequest();
            }

            var person = _db.Persons.FirstOrDefault(u => u.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            var personDTO = _mapper.Map<PersonDTO>(person);

            patchDTO.ApplyTo(personDTO, ModelState);

            TryValidateModel(personDTO);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(personDTO, person);

            person.UpdatedDate = DateTime.Now;

            _db.SaveChanges();

            return NoContent();
        }

    }
}
