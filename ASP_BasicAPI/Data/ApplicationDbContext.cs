using ASP_BasicAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_BasicAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

    }
}
