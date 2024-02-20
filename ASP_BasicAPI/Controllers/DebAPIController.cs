using ASP_BasicAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP_BasicAPI.Controllers
{
    [Route("api/DebAPI")]
    [ApiController]
    public class DebAPIController : Controller 
    {
        [HttpGet]
        public IEnumerable<Person> Persons()
        {
            return new List<Person>
            {
                new Person{ Id = 1, Name = "Sujon Roy"},
                new Person{ Id = 2, Name = "Polok Roy"}
            };
        }
    }
}
