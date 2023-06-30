using PersonManagement.Domain.Entities;
using AutoMapper;

namespace PersonManagement.Application
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Person, PersonDTO>().ReverseMap();
        }
    }
}
