namespace HospitalAPI.Person
{
    public interface IPersonService
    {
        Task<IEnumerable<PersonDTO>> GetAllAsync();
        Task<PersonDTO?> GetByIdAsync(int id);
        Task<PersonDTO> CreateAsync(PersonDTO dto);
        Task<PersonDTO?> UpdateAsync(int id, PersonDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
