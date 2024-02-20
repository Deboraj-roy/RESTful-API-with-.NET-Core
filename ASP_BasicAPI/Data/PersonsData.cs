using ASP_BasicAPI.Models.DTO;

namespace ASP_BasicAPI.Data
{
    public static class PersonsData
    {
        public static List<PersonDTO> personList = new List<PersonDTO>
            {
                new PersonDTO{ Id = 1, Name = "Sujon Roy", Gender = 'M', Age = 20 },
                new PersonDTO{ Id = 2, Name = "Polok Roy", Gender = 'M', Age = 23}
            };
    }
}
