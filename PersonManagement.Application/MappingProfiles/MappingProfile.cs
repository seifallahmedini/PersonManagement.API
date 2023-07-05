using PersonManagement.Domain.Entities;
using AutoMapper;
using PersonManagement.Application.DTOs;

namespace PersonManagement.Application
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Person, PersonRequestDTO>().ReverseMap();
            CreateMap<Person, PersonResponseDTO>().ReverseMap();
        }
    }
}
