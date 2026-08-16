namespace HospitalAPI.Study
{
    public interface IStudyService
    {
        Task<IEnumerable<StudyDetailsDTO>> GetAllAsync();
        Task<StudyDetailsDTO?> GetByIdAsync(int id);
        Task<IEnumerable<StudyDetailsDTO>> GetByPatientIdAsync(int patientId);
        Task<IEnumerable<StudyDetailsDTO>> GetByDoctorIdAsync(int doctorId);
        Task<StudyDetailsDTO> CreateAsync(CreateStudyRequest request);
        Task<StudyDetailsDTO?> UpdateAsync(int id, CreateStudyRequest request);
        Task<bool> DeleteAsync(int id);
    }
}
