using HospitalAPI.Data;
using HospitalAPI.Shared;
using Microsoft.EntityFrameworkCore;

namespace HospitalAPI.Study
{
    public class StudyRepository : IStudyRepository
    {
        private readonly AppDbContext _context;

        public StudyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StudyModel>> GetAllAsync()
        {
            return await _context.Studies
                .Include(s => s.Patient).ThenInclude(p => p.Person)
                .Include(s => s.Doctor).ThenInclude(d => d.Person)
                .ToListAsync();
        }

        public async Task<StudyModel?> GetByIdAsync(int id)
        {
            return await _context.Studies
                .Include(s => s.Patient).ThenInclude(p => p.Person)
                .Include(s => s.Doctor).ThenInclude(d => d.Person)
                .FirstOrDefaultAsync(s => s.StudyId == id);
        }

        public async Task<StudyModel> AddAsync(StudyModel entity)
        {
            _context.Studies.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<StudyModel?> UpdateAsync(int id, StudyModel entity)
        {
            var existing = await _context.Studies.FindAsync(id);
            if (existing == null) return null;

            existing.PatientId = entity.PatientId;
            existing.DoctorId = entity.DoctorId;
            existing.Modality = entity.Modality;
            existing.StudyDate = entity.StudyDate;
            existing.Status = entity.Status;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Studies.FindAsync(id);
            if (entity == null) return false;

            _context.Studies.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Studies.AnyAsync(e => e.StudyId == id);
        }

        public async Task<IEnumerable<StudyModel>> GetByPatientIdAsync(int patientId)
        {
            return await _context.Studies
                .Include(s => s.Patient).ThenInclude(p => p.Person)
                .Include(s => s.Doctor).ThenInclude(d => d.Person)
                .Where(s => s.PatientId == patientId)
                .ToListAsync();
        }

        public async Task<IEnumerable<StudyModel>> GetByDoctorIdAsync(int doctorId)
        {
            return await _context.Studies
                .Include(s => s.Patient).ThenInclude(p => p.Person)
                .Include(s => s.Doctor).ThenInclude(d => d.Person)
                .Where(s => s.DoctorId == doctorId)
                .ToListAsync();
        }
    }
}
