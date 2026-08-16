using HospitalAPI.Data;
using HospitalAPI.Shared;
using Microsoft.EntityFrameworkCore;

namespace HospitalAPI.Doctor
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly AppDbContext _context;

        public DoctorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DoctorModel>> GetAllAsync()
        {
            return await _context.Doctors.Include(d => d.Person).ToListAsync();
        }

        public async Task<DoctorModel?> GetByIdAsync(int id)
        {
            return await _context.Doctors.Include(d => d.Person).FirstOrDefaultAsync(d => d.DoctorId == id);
        }

        public async Task<DoctorModel> AddAsync(DoctorModel entity)
        {
            _context.Doctors.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<DoctorModel?> UpdateAsync(int id, DoctorModel entity)
        {
            var existing = await _context.Doctors.FindAsync(id);
            if (existing == null) return null;

            existing.PersonId = entity.PersonId;
            existing.Specialty = entity.Specialty;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Doctors.FindAsync(id);
            if (entity == null) return false;

            _context.Doctors.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Doctors.AnyAsync(e => e.DoctorId == id);
        }

        public async Task<IEnumerable<DoctorModel>> GetBySpecialtyAsync(string specialty)
        {
            return await _context.Doctors
                .Include(d => d.Person)
                .Where(d => d.Specialty.ToLower() == specialty.ToLower())
                .ToListAsync();
        }
    }
}
