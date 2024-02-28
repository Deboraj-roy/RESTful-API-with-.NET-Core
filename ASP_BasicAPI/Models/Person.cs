namespace ASP_BasicAPI.Models
{
    // my data in Database 
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public char Gender { get; set; }
        public int Age { get; set; }
        public string Details { get; set; }
        public double Salary { get; set; }
        public string ImageUrl { get; set; }
        public string Occupation { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
