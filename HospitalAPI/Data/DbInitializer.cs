using HospitalAPI.Person;
using HospitalAPI.Patient;
using HospitalAPI.Doctor;
using HospitalAPI.Study;
using Microsoft.EntityFrameworkCore;

namespace HospitalAPI.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Persons.Any())
                return;

            var persons = new PersonModel[]
            {
                new PersonModel { FirstName = "Ahmed", LastName = "Ali", DateOfBirth = new DateTime(2001, 5, 15), Gender = "Male", Phone = "01011111111", Email = "ahmed.ali@email.com" },
                new PersonModel { FirstName = "Sara", LastName = "Mohamed", DateOfBirth = new DateTime(1996, 8, 22), Gender = "Female", Phone = "01022222222", Email = "sara.mohamed@email.com" },
                new PersonModel { FirstName = "Omar", LastName = "Hassan", DateOfBirth = new DateTime(1981, 3, 10), Gender = "Male", Phone = "01033333333", Email = "omar.hassan@email.com" },
                new PersonModel { FirstName = "Mona", LastName = "Adel", DateOfBirth = new DateTime(1988, 11, 5), Gender = "Female", Phone = "01044444444", Email = "mona.adel@email.com" }
            };
            context.Persons.AddRange(persons);
            context.SaveChanges();

            var patients = new PatientModel[]
            {
                new PatientModel { PersonId = 1, MRN = "MRN-001", Status = "Active" },
                new PatientModel { PersonId = 2, MRN = "MRN-002", Status = "Active" }
            };
            context.Patients.AddRange(patients);
            context.SaveChanges();

            var doctors = new DoctorModel[]
            {
                new DoctorModel { PersonId = 3, Specialty = "Cardiology" },
                new DoctorModel { PersonId = 4, Specialty = "Neurology" }
            };
            context.Doctors.AddRange(doctors);
            context.SaveChanges();

            var studies = new StudyModel[]
            {
                new StudyModel { PatientId = 1, DoctorId = 1, Modality = "X-Ray", StudyDate = new DateTime(2026, 7, 20), Status = "Completed" },
                new StudyModel { PatientId = 2, DoctorId = 2, Modality = "MRI", StudyDate = new DateTime(2026, 7, 21), Status = "Pending" }
            };
            context.Studies.AddRange(studies);
            context.SaveChanges();
        }
    }
}
