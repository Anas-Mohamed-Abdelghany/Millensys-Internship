using HospitalAPI.Data;
using HospitalAPI.Shared;
using Microsoft.EntityFrameworkCore;

namespace HospitalAPI.Patient
{
    public class PatientRepository : IPatientRepository
    {
        private readonly AppDbContext _context;

        public PatientRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PatientModel>> GetAllAsync()
        {
            return await _context.Patients.Include(p => p.Person).ToListAsync();
        }

        public async Task<PatientModel?> GetByIdAsync(int id)
        {
            return await _context.Patients.Include(p => p.Person).FirstOrDefaultAsync(p => p.PatientId == id);
        }

        public async Task<PatientModel> AddAsync(PatientModel entity)
        {
            _context.Patients.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<PatientModel?> UpdateAsync(int id, PatientModel entity)
        {
            var existing = await _context.Patients.FindAsync(id);
            if (existing == null) return null;

            existing.PersonId = entity.PersonId;
            existing.MRN = entity.MRN;
            existing.Status = entity.Status;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Patients.FindAsync(id);
            if (entity == null) return false;

            _context.Patients.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Patients.AnyAsync(e => e.PatientId == id);
        }

        public async Task<IEnumerable<PatientModel>> GetByStatusAsync(string status)
        {
            return await _context.Patients
                .Include(p => p.Person)
                .Where(p => p.Status.ToLower() == status.ToLower())
                .ToListAsync();
        }
    }
}
