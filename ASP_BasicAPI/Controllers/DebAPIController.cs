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
        public IEnumerable<PersonDTO> Persons()
        {
            return new List<PersonDTO>
            {
                new PersonDTO{ Id = 1, Name = "Sujon Roy"},
                new PersonDTO{ Id = 2, Name = "Polok Roy"}
            };
        }
    }
}
