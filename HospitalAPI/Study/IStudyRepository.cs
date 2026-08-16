using HospitalAPI.Shared;

namespace HospitalAPI.Study
{
    public interface IStudyRepository : IRepository<StudyModel>
    {
        Task<IEnumerable<StudyModel>> GetByPatientIdAsync(int patientId);
        Task<IEnumerable<StudyModel>> GetByDoctorIdAsync(int doctorId);
    }
}
