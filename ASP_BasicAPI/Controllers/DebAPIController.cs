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
        public ActionResult<IEnumerable<PersonDTO>> GetPersons()
        {
            //ActionResult we can return any type of returntype
            return Ok(PersonsData.personList);
        }

        [HttpGet("{id:int}")] // Mention that you required ID
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
    }
}
