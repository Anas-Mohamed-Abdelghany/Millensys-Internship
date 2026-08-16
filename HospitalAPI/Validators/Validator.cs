using FluentValidation;

namespace HospitalAPI.Validators
{
    public class PersonDTOValidator : AbstractValidator<Person.PersonDTO>
    {
        public PersonDTOValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.DateOfBirth).NotEmpty().LessThanOrEqualTo(DateTime.Now);
            RuleFor(x => x.Gender).MaximumLength(10);
            RuleFor(x => x.Phone).MaximumLength(20).Matches(@"^[0-9+\-\s()]*$");
            RuleFor(x => x.Email).MaximumLength(100).EmailAddress();
        }
    }

    public class PatientDTOValidator : AbstractValidator<Patient.PatientDTO>
    {
        public PatientDTOValidator()
        {
            RuleFor(x => x.PersonId).GreaterThan(0);
            RuleFor(x => x.MRN).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Status).MaximumLength(20);
        }
    }

    public class CreatePatientRequestValidator : AbstractValidator<Patient.CreatePatientRequest>
    {
        public CreatePatientRequestValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.DateOfBirth).NotEmpty().LessThanOrEqualTo(DateTime.Now);
            RuleFor(x => x.Gender).MaximumLength(10);
            RuleFor(x => x.Phone).MaximumLength(20).Matches(@"^[0-9+\-\s()]*$");
            RuleFor(x => x.Email).MaximumLength(100).EmailAddress();
            RuleFor(x => x.MRN).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Status).MaximumLength(20);
        }
    }

    public class DoctorDTOValidator : AbstractValidator<Doctor.DoctorDTO>
    {
        public DoctorDTOValidator()
        {
            RuleFor(x => x.PersonId).GreaterThan(0);
            RuleFor(x => x.Specialty).NotEmpty().MaximumLength(100);
        }
    }

    public class CreateDoctorRequestValidator : AbstractValidator<Doctor.CreateDoctorRequest>
    {
        public CreateDoctorRequestValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.DateOfBirth).NotEmpty().LessThanOrEqualTo(DateTime.Now);
            RuleFor(x => x.Gender).MaximumLength(10);
            RuleFor(x => x.Phone).MaximumLength(20).Matches(@"^[0-9+\-\s()]*$");
            RuleFor(x => x.Email).MaximumLength(100).EmailAddress();
            RuleFor(x => x.Specialty).NotEmpty().MaximumLength(100);
        }
    }

    public class StudyDTOValidator : AbstractValidator<Study.StudyDTO>
    {
        public StudyDTOValidator()
        {
            RuleFor(x => x.PatientId).GreaterThan(0);
            RuleFor(x => x.DoctorId).GreaterThan(0);
            RuleFor(x => x.Modality).NotEmpty().MaximumLength(50);
            RuleFor(x => x.StudyDate).NotEmpty().LessThanOrEqualTo(DateTime.Now.AddDays(1));
            RuleFor(x => x.Status).MaximumLength(20);
        }
    }

    public class CreateStudyRequestValidator : AbstractValidator<Study.CreateStudyRequest>
    {
        public CreateStudyRequestValidator()
        {
            RuleFor(x => x.PatientId).GreaterThan(0);
            RuleFor(x => x.DoctorId).GreaterThan(0);
            RuleFor(x => x.Modality).NotEmpty().MaximumLength(50);
            RuleFor(x => x.StudyDate).NotEmpty().LessThanOrEqualTo(DateTime.Now.AddDays(1));
            RuleFor(x => x.Status).MaximumLength(20);
        }
    }
}
