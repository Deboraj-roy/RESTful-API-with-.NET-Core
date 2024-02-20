using ASP_BasicAPI.Data;
using ASP_BasicAPI.Models;
using ASP_BasicAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ASP_BasicAPI.Controllers
{
    //[Route("api/[Controller]")
    [Route("api/DebAPI")]
    [ApiController]
    public class DebAPIController : Controller
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<PersonDTO>> GetPersons()
        {
            //ActionResult we can return any type of returntype
            return Ok(PersonsData.personList);
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
            var person = PersonsData.personList.FirstOrDefault(u => u.Id == id);
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
            if (personDTO == null)
            {
                return BadRequest(personDTO);
            }

            if (personDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            personDTO.Id = PersonsData.personList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
            PersonsData.personList.Add(personDTO);

            //return Ok(personDTO);
            return CreatedAtRoute("GetPerson", new { id = personDTO.Id }, personDTO);
        }

    }
}
