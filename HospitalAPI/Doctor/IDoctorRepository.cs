using HospitalAPI.Shared;

namespace HospitalAPI.Doctor
{
    public interface IDoctorRepository : IRepository<DoctorModel>
    {
        Task<IEnumerable<DoctorModel>> GetBySpecialtyAsync(string specialty);
    }
}
