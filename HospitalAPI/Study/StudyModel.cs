using System.ComponentModel.DataAnnotations;

namespace HospitalAPI.Study
{
    public class StudyModel
    {
        [Key]
        public int StudyId { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Modality { get; set; } = string.Empty;

        public DateTime StudyDate { get; set; }

        [MaxLength(20)]
        public string Status { get; set; } = string.Empty;

        public Patient.PatientModel Patient { get; set; } = null!;
        public Doctor.DoctorModel Doctor { get; set; } = null!;
    }
}
