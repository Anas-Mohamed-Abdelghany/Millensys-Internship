using HospitalAPI.Data;
using HospitalAPI.Shared;
using Microsoft.EntityFrameworkCore;

namespace HospitalAPI.Person
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AppDbContext _context;

        public PersonRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PersonModel>> GetAllAsync()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task<PersonModel?> GetByIdAsync(int id)
        {
            return await _context.Persons.FindAsync(id);
        }

        public async Task<PersonModel> AddAsync(PersonModel entity)
        {
            _context.Persons.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<PersonModel?> UpdateAsync(int id, PersonModel entity)
        {
            var existing = await _context.Persons.FindAsync(id);
            if (existing == null) return null;

            existing.FirstName = entity.FirstName;
            existing.LastName = entity.LastName;
            existing.DateOfBirth = entity.DateOfBirth;
            existing.Gender = entity.Gender;
            existing.Phone = entity.Phone;
            existing.Email = entity.Email;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Persons.FindAsync(id);
            if (entity == null) return false;

            _context.Persons.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Persons.AnyAsync(e => e.PersonId == id);
        }
    }
}
