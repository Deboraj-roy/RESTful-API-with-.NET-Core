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
    }
}
