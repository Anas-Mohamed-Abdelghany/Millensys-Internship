using HospitalAPI.Doctor;
using HospitalAPI.Patient;

namespace HospitalAPI.Study
{
    public class StudyService : IStudyService
    {
        private readonly IStudyRepository _studyRepo;
        private readonly IDoctorRepository _doctorRepo;
        private readonly IPatientRepository _patientRepo;

        public StudyService(IStudyRepository studyRepo, IDoctorRepository doctorRepo, IPatientRepository patientRepo)
        {
            _studyRepo = studyRepo;
            _doctorRepo = doctorRepo;
            _patientRepo = patientRepo;
        }

        public async Task<IEnumerable<StudyDetailsDTO>> GetAllAsync()
        {
            var studies = await _studyRepo.GetAllAsync();
            return studies.Select(MapToDetailsDTO);
        }

        public async Task<StudyDetailsDTO?> GetByIdAsync(int id)
        {
            var study = await _studyRepo.GetByIdAsync(id);
            return study == null ? null : MapToDetailsDTO(study);
        }

        public async Task<IEnumerable<StudyDetailsDTO>> GetByPatientIdAsync(int patientId)
        {
            var studies = await _studyRepo.GetByPatientIdAsync(patientId);
            return studies.Select(MapToDetailsDTO);
        }

        public async Task<IEnumerable<StudyDetailsDTO>> GetByDoctorIdAsync(int doctorId)
        {
            var studies = await _studyRepo.GetByDoctorIdAsync(doctorId);
            return studies.Select(MapToDetailsDTO);
        }

        public async Task<StudyDetailsDTO> CreateAsync(CreateStudyRequest request)
        {
            var study = new StudyModel
            {
                PatientId = request.PatientId,
                DoctorId = request.DoctorId,
                Modality = request.Modality,
                StudyDate = request.StudyDate,
                Status = request.Status
            };
            var created = await _studyRepo.AddAsync(study);

            return new StudyDetailsDTO
            {
                StudyId = created.StudyId,
                PatientId = created.PatientId,
                DoctorId = created.DoctorId,
                Modality = created.Modality,
                StudyDate = created.StudyDate,
                Status = created.Status
            };
        }

        public async Task<StudyDetailsDTO?> UpdateAsync(int id, CreateStudyRequest request)
        {
            var study = new StudyModel
            {
                PatientId = request.PatientId,
                DoctorId = request.DoctorId,
                Modality = request.Modality,
                StudyDate = request.StudyDate,
                Status = request.Status
            };
            var updated = await _studyRepo.UpdateAsync(id, study);
            if (updated == null) return null;

            return new StudyDetailsDTO
            {
                StudyId = updated.StudyId,
                PatientId = updated.PatientId,
                DoctorId = updated.DoctorId,
                Modality = updated.Modality,
                StudyDate = updated.StudyDate,
                Status = updated.Status
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _studyRepo.DeleteAsync(id);
        }

        private static StudyDetailsDTO MapToDetailsDTO(StudyModel s)
        {
            return new StudyDetailsDTO
            {
                StudyId = s.StudyId,
                PatientId = s.PatientId,
                DoctorId = s.DoctorId,
                PatientName = $"{s.Patient.Person.FirstName} {s.Patient.Person.LastName}",
                DoctorName = $"{s.Doctor.Person.FirstName} {s.Doctor.Person.LastName}",
                Modality = s.Modality,
                StudyDate = s.StudyDate,
                Status = s.Status
            };
        }
    }
}
