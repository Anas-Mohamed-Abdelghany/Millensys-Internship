using System.ComponentModel.DataAnnotations;

namespace HospitalAPI.Doctor
{
    public class DoctorDTO
    {
        public int DoctorId { get; set; }

        [Required]
        public int PersonId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Specialty { get; set; } = string.Empty;
    }

    public class DoctorWithPersonDTO
    {
        public int DoctorId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Specialty { get; set; } = string.Empty;
    }

    public class CreateDoctorRequest
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }

        [MaxLength(10)]
        public string Gender { get; set; } = string.Empty;

        [MaxLength(20)]
        public string Phone { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Specialty { get; set; } = string.Empty;
    }
}
