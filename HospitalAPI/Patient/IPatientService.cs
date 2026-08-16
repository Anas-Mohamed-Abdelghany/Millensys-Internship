namespace HospitalAPI.Patient
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientWithPersonDTO>> GetAllAsync();
        Task<PatientWithPersonDTO?> GetByIdAsync(int id);
        Task<IEnumerable<PatientWithPersonDTO>> GetByStatusAsync(string status);
        Task<PatientWithPersonDTO> CreateAsync(CreatePatientRequest request);
        Task<PatientWithPersonDTO?> UpdateAsync(int id, CreatePatientRequest request);
        Task<bool> DeleteAsync(int id);
    }
}
