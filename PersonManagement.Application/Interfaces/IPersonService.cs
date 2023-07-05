using PersonManagement.Application.DTOs;

namespace PersonManagement.Application
{
    public interface IPersonService
    {
        Task<IEnumerable<PersonResponseDTO>> GetAllAsync();
        Task<PersonResponseDTO> AddAsync(PersonRequestDTO person);
    }
}
