﻿using ASP_BasicAPI.Data;
using ASP_BasicAPI.Models;
using ASP_BasicAPI.Models.DTO;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ASP_BasicAPI.Controllers
{
    //[Route("api/[Controller]")
    [Route("api/DebAPI")]
    [ApiController]
    public class DebAPIController : Controller
    {
        private readonly ILogger<PersonDTO> _logger;

        public DebAPIController(ILogger<PersonDTO> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<PersonDTO>> GetPersons()
        {
            _logger.LogInformation("Get all people");
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
                _logger.LogError("Get Person error with Id: " + id);
                return BadRequest();
            }
            var person = PersonsData.personList.FirstOrDefault(u => u.Id == id);
            if (person == null)
            {
                _logger.LogInformation("Person Not Found with Id: " + id);
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

            if (PersonsData.personList.FirstOrDefault(u => u.Name.ToLower() == personDTO.Name.ToLower()) != null)
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

            personDTO.Id = PersonsData.personList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
            PersonsData.personList.Add(personDTO);

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

            var person = PersonsData.personList.FirstOrDefault(u => u.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            PersonsData.personList.Remove(person);
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
            var person = PersonsData.personList.FirstOrDefault(u => u.Id == id);
            if (person == null)
            {
                return NotFound();
            }
            person.Name = personDTO.Name;
            person.Gender = personDTO.Gender;
            person.Age = personDTO.Age;

            return NoContent();
        }

        [HttpPatch("{id:int}", Name = "UpdatePartialPerson")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePartialPerson(int id, JsonPatchDocument<PersonDTO> personDTO)
        {
            if (personDTO == null || id == 0)
            {
                return BadRequest();
            }
            var person = PersonsData.personList.FirstOrDefault(u => u.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            personDTO.ApplyTo(person, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return NoContent();
        }

    }
}
