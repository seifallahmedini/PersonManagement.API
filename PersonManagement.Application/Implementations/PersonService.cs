
using AutoMapper;
using PersonManagement.Domain.Interfaces;
using PersonManagement.Domain.Entities;
using PersonManagement.Application.Exceptions;
using System;
using PersonManagement.Application.DTOs;

namespace PersonManagement.Application
{
    public class PersonService : IPersonService
    {
        private readonly IRepository<Person> _personRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PersonService(IRepository<Person> personRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _personRepository = personRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PersonResponseDTO>> GetAllAsync()
        {
            var persons = await _personRepository.GetAllAsync();

            var personsWithAge = persons
                .OrderBy(p => p.FirstName)
                .Select(p => new PersonResponseDTO
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    Age = CalculateAge(p.Birthday)
                });
            return _mapper.Map<IEnumerable<PersonResponseDTO>>(personsWithAge);
        }

        public async Task<PersonResponseDTO> AddAsync(PersonRequestDTO personDto)
        {
            int age = CalculateAge(personDto.Birthday);
            if (age >= 150)
            {
                throw new InvalidAgeException("Invalid age. Age must be at least 150.");
            }

            var person = _mapper.Map<Person>(personDto);
            person.Id = Guid.NewGuid();
            await _personRepository.AddAsync(person);
            await _unitOfWork.SaveChangesAsync();

            var personResponseDto = _mapper.Map<PersonResponseDTO>(person);
            personResponseDto.Age = age;

            return personResponseDto;
        }


        public static int CalculateAge(DateTime birthDate)
        {
            DateTime currentDate = DateTime.Today;
            int age = currentDate.Year - birthDate.Year;
            if (birthDate > currentDate.AddYears(-age))
            {
                age--;
            }

            return age;
        }
    }
}
