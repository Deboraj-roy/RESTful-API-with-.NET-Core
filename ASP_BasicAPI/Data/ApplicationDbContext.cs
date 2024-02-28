using ASP_BasicAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_BasicAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(
                new Person
                {
                    Id = 1,
                    Name = "John Doe",
                    Gender = 'M',
                    Age = 30,
                    Details = "Software Engineer",
                    Salary = 75000.00,
                    ImageUrl = "https://example.com/john-doe.jpg",
                    Occupation = "Engineer",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                },
                new Person
                {
                    Id = 2,
                    Name = "Jane Smith",
                    Gender = 'F',
                    Age = 28,
                    Details = "Data Scientist",
                    Salary = 80000.00,
                    ImageUrl = "https://example.com/jane-smith.jpg",
                    Occupation = "Data Scientist",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                },
                new Person
                {
                    Id = 3,
                    Name = "Michael Johnson",
                    Gender = 'M',
                    Age = 35,
                    Details = "Doctor",
                    Salary = 120000.00,
                    ImageUrl = "https://example.com/michael-johnson.jpg",
                    Occupation = "Doctor",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                },
                new Person
                {
                    Id = 4,
                    Name = "Emily Brown",
                    Gender = 'F',
                    Age = 25,
                    Details = "Teacher",
                    Salary = 50000.00,
                    ImageUrl = "https://example.com/emily-brown.jpg",
                    Occupation = "Teacher",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                },
                new Person
                {
                    Id = 5,
                    Name = "David Wilson",
                    Gender = 'M',
                    Age = 40,
                    Details = "Lawyer",
                    Salary = 100000.00,
                    ImageUrl = "https://example.com/david-wilson.jpg",
                    Occupation = "Lawyer",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                }
            );

            //base.OnModelCreating(modelBuilder);
        }
        public DbSet<Person> Persons { get; set; }

    }
}
