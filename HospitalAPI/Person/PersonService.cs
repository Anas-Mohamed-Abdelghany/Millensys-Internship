namespace HospitalAPI.Person
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _repository;

        public PersonService(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PersonDTO>> GetAllAsync()
        {
            var persons = await _repository.GetAllAsync();
            return persons.Select(MapToDTO);
        }

        public async Task<PersonDTO?> GetByIdAsync(int id)
        {
            var person = await _repository.GetByIdAsync(id);
            return person == null ? null : MapToDTO(person);
        }

        public async Task<PersonDTO> CreateAsync(PersonDTO dto)
        {
            var person = new PersonModel
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                DateOfBirth = dto.DateOfBirth,
                Gender = dto.Gender,
                Phone = dto.Phone,
                Email = dto.Email
            };
            var created = await _repository.AddAsync(person);
            dto.PersonId = created.PersonId;
            return dto;
        }

        public async Task<PersonDTO?> UpdateAsync(int id, PersonDTO dto)
        {
            var person = new PersonModel
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                DateOfBirth = dto.DateOfBirth,
                Gender = dto.Gender,
                Phone = dto.Phone,
                Email = dto.Email
            };
            var updated = await _repository.UpdateAsync(id, person);
            if (updated == null) return null;
            dto.PersonId = updated.PersonId;
            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        private static PersonDTO MapToDTO(PersonModel p)
        {
            return new PersonDTO
            {
                PersonId = p.PersonId,
                FirstName = p.FirstName,
                LastName = p.LastName,
                DateOfBirth = p.DateOfBirth,
                Gender = p.Gender,
                Phone = p.Phone,
                Email = p.Email
            };
        }
    }
}
