namespace HospitalAPI.Doctor
{
    public interface IDoctorService
    {
        Task<IEnumerable<DoctorWithPersonDTO>> GetAllAsync();
        Task<DoctorWithPersonDTO?> GetByIdAsync(int id);
        Task<IEnumerable<DoctorWithPersonDTO>> GetBySpecialtyAsync(string specialty);
        Task<DoctorWithPersonDTO> CreateAsync(CreateDoctorRequest request);
        Task<DoctorWithPersonDTO?> UpdateAsync(int id, CreateDoctorRequest request);
        Task<bool> DeleteAsync(int id);
    }
}
