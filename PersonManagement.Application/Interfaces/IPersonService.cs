namespace PersonManagement.Application
{
    public interface IPersonService
    {
        Task<PersonDTO> GetByIdAsync(Guid id);
        Task<IEnumerable<PersonDTO>> GetAllAsync();
        Task<PersonDTO> AddAsync(PersonDTO person);
        Task<PersonDTO> UpdateAsync(Guid id, PersonDTO personDto);
        Task<PersonDTO> DeleteAsync(Guid id);
    }
}
