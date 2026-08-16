using HospitalAPI.Shared;

namespace HospitalAPI.Patient
{
    public interface IPatientRepository : IRepository<PatientModel>
    {
        Task<IEnumerable<PatientModel>> GetByStatusAsync(string status);
    }
}
