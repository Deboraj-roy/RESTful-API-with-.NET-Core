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
        public IEnumerable<PersonDTO> GetPersons()
        {
            return PersonsData.personList;
        }

        [HttpGet("{id:int}")] // Mention that you required ID
        public PersonDTO GetPerson(int id)
        {
            return PersonsData.personList.FirstOrDefault(u => u.Id == id);
        }
    }
}
