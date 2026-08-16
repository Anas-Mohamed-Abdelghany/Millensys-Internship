using HospitalAPI.Person;

namespace HospitalAPI.Patient
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepo;
        private readonly IPersonRepository _personRepo;

        public PatientService(IPatientRepository patientRepo, IPersonRepository personRepo)
        {
            _patientRepo = patientRepo;
            _personRepo = personRepo;
        }

        public async Task<IEnumerable<PatientWithPersonDTO>> GetAllAsync()
        {
            var patients = await _patientRepo.GetAllAsync();
            return patients.Select(MapToWithPersonDTO);
        }

        public async Task<PatientWithPersonDTO?> GetByIdAsync(int id)
        {
            var patient = await _patientRepo.GetByIdAsync(id);
            return patient == null ? null : MapToWithPersonDTO(patient);
        }

        public async Task<IEnumerable<PatientWithPersonDTO>> GetByStatusAsync(string status)
        {
            var patients = await _patientRepo.GetByStatusAsync(status);
            return patients.Select(MapToWithPersonDTO);
        }

        public async Task<PatientWithPersonDTO> CreateAsync(CreatePatientRequest request)
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

            var patient = new PatientModel
            {
                PersonId = createdPerson.PersonId,
                MRN = request.MRN,
                Status = request.Status
            };
            var createdPatient = await _patientRepo.AddAsync(patient);

            return new PatientWithPersonDTO
            {
                PatientId = createdPatient.PatientId,
                FirstName = createdPerson.FirstName,
                LastName = createdPerson.LastName,
                DateOfBirth = createdPerson.DateOfBirth,
                Gender = createdPerson.Gender,
                Phone = createdPerson.Phone,
                Email = createdPerson.Email,
                MRN = createdPatient.MRN,
                Status = createdPatient.Status
            };
        }

        public async Task<PatientWithPersonDTO?> UpdateAsync(int id, CreatePatientRequest request)
        {
            var patient = await _patientRepo.GetByIdAsync(id);
            if (patient == null) return null;

            var person = await _personRepo.GetByIdAsync(patient.PersonId);
            if (person == null) return null;

            person.FirstName = request.FirstName;
            person.LastName = request.LastName;
            person.DateOfBirth = request.DateOfBirth;
            person.Gender = request.Gender;
            person.Phone = request.Phone;
            person.Email = request.Email;
            await _personRepo.UpdateAsync(person.PersonId, person);

            patient.MRN = request.MRN;
            patient.Status = request.Status;
            await _patientRepo.UpdateAsync(id, patient);

            return new PatientWithPersonDTO
            {
                PatientId = id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                DateOfBirth = person.DateOfBirth,
                Gender = person.Gender,
                Phone = person.Phone,
                Email = person.Email,
                MRN = patient.MRN,
                Status = patient.Status
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _patientRepo.DeleteAsync(id);
        }

        private static PatientWithPersonDTO MapToWithPersonDTO(PatientModel p)
        {
            return new PatientWithPersonDTO
            {
                PatientId = p.PatientId,
                FirstName = p.Person.FirstName,
                LastName = p.Person.LastName,
                DateOfBirth = p.Person.DateOfBirth,
                Gender = p.Person.Gender,
                Phone = p.Person.Phone,
                Email = p.Person.Email,
                MRN = p.MRN,
                Status = p.Status
            };
        }
    }
}
