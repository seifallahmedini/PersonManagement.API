
using AutoMapper;
using PersonManagement.Domain.Interfaces;
using PersonManagement.Domain.Entities;

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

        public async Task<PersonDTO> GetByIdAsync(Guid id)
        {
            var person = await _personRepository.GetByIdAsync(id);
            return _mapper.Map<PersonDTO>(person);
        }

        public async Task<IEnumerable<PersonDTO>> GetAllAsync()
        {
            var persons = await _personRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PersonDTO>>(persons);
        }

        public async Task<PersonDTO> AddAsync(PersonDTO personDto)
        {
            var person = _mapper.Map<Person>(personDto);
            person.Id = Guid.NewGuid();
            await _personRepository.AddAsync(person);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<PersonDTO>(person);
        }

        public async Task<PersonDTO> UpdateAsync(Guid id, PersonDTO personDto)
        {
            var person = await _personRepository.GetByIdAsync(id);
            if (person == null)
            {
                throw new ArgumentException($"Entity with id {id} not found.");
            }
            personDto.Id = person.Id;

            _mapper.Map(personDto, person);

            await _personRepository.UpdateAsync(person);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<PersonDTO>(person);
        }

        public async Task<PersonDTO> DeleteAsync(Guid id)
        {
            var person = await _personRepository.GetByIdAsync(id);
            await _personRepository.DeleteAsync(person);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<PersonDTO>(person);
        }
    }
}
