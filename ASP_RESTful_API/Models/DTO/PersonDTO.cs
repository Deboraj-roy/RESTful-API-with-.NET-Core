using System.ComponentModel.DataAnnotations;

namespace ASP_BasicAPI.Models.DTO
{
    // i wanna to expose data through API
    public class PersonDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public char Gender { get; set; }
        public int Age { get; set;} 
        public string Details { get; set; }
        public double Salary { get; set; }
        public string ImageUrl { get; set; }
        public string Occupation { get; set; }
    }
}
