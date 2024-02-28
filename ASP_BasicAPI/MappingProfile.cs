using ASP_BasicAPI.Models;
using ASP_BasicAPI.Models.DTO;
using AutoMapper;

namespace ASP_BasicAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Person, PersonDTO>().ReverseMap();
        }
    }
}
