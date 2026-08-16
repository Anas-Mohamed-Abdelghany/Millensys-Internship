using HospitalAPI.Person;

namespace HospitalAPI.Doctor
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepo;
        private readonly IPersonRepository _personRepo;

        public DoctorService(IDoctorRepository doctorRepo, IPersonRepository personRepo)
        {
            _doctorRepo = doctorRepo;
            _personRepo = personRepo;
        }

        public async Task<IEnumerable<DoctorWithPersonDTO>> GetAllAsync()
        {
            var doctors = await _doctorRepo.GetAllAsync();
            return doctors.Select(MapToWithPersonDTO);
        }

        public async Task<DoctorWithPersonDTO?> GetByIdAsync(int id)
        {
            var doctor = await _doctorRepo.GetByIdAsync(id);
            return doctor == null ? null : MapToWithPersonDTO(doctor);
        }

        public async Task<IEnumerable<DoctorWithPersonDTO>> GetBySpecialtyAsync(string specialty)
        {
            var doctors = await _doctorRepo.GetBySpecialtyAsync(specialty);
            return doctors.Select(MapToWithPersonDTO);
        }

        public async Task<DoctorWithPersonDTO> CreateAsync(CreateDoctorRequest request)
        {
            var person = new PersonModel
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
                Gender = request.Gender,
                Phone = request.Phone,
                Email = request.Email
            };
            var createdPerson = await _personRepo.AddAsync(person);

            var doctor = new DoctorModel
            {
                PersonId = createdPerson.PersonId,
                Specialty = request.Specialty
            };
            var createdDoctor = await _doctorRepo.AddAsync(doctor);

            return new DoctorWithPersonDTO
            {
                DoctorId = createdDoctor.DoctorId,
                FirstName = createdPerson.FirstName,
                LastName = createdPerson.LastName,
                DateOfBirth = createdPerson.DateOfBirth,
                Gender = createdPerson.Gender,
                Phone = createdPerson.Phone,
                Email = createdPerson.Email,
                Specialty = createdDoctor.Specialty
            };
        }

        public async Task<DoctorWithPersonDTO?> UpdateAsync(int id, CreateDoctorRequest request)
        {
            var doctor = await _doctorRepo.GetByIdAsync(id);
            if (doctor == null) return null;

            var person = await _personRepo.GetByIdAsync(doctor.PersonId);
            if (person == null) return null;

            person.FirstName = request.FirstName;
            person.LastName = request.LastName;
            person.DateOfBirth = request.DateOfBirth;
            person.Gender = request.Gender;
            person.Phone = request.Phone;
            person.Email = request.Email;
            await _personRepo.UpdateAsync(person.PersonId, person);

            doctor.Specialty = request.Specialty;
            await _doctorRepo.UpdateAsync(id, doctor);

            return new DoctorWithPersonDTO
            {
                DoctorId = id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                DateOfBirth = person.DateOfBirth,
                Gender = person.Gender,
                Phone = person.Phone,
                Email = person.Email,
                Specialty = doctor.Specialty
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _doctorRepo.DeleteAsync(id);
        }

        private static DoctorWithPersonDTO MapToWithPersonDTO(DoctorModel d)
        {
            return new DoctorWithPersonDTO
            {
                DoctorId = d.DoctorId,
                FirstName = d.Person.FirstName,
                LastName = d.Person.LastName,
                DateOfBirth = d.Person.DateOfBirth,
                Gender = d.Person.Gender,
                Phone = d.Person.Phone,
                Email = d.Person.Email,
                Specialty = d.Specialty
            };
        }
    }
}
