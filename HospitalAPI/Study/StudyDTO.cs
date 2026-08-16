using System.ComponentModel.DataAnnotations;

namespace HospitalAPI.Study
{
    public class StudyDTO
    {
        public int StudyId { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Modality { get; set; } = string.Empty;

        public DateTime StudyDate { get; set; }

        [MaxLength(20)]
        public string Status { get; set; } = string.Empty;
    }

    public class StudyDetailsDTO
    {
        public int StudyId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public string DoctorName { get; set; } = string.Empty;
        public string Modality { get; set; } = string.Empty;
        public DateTime StudyDate { get; set; }
        public string Status { get; set; } = string.Empty;
    }

    public class CreateStudyRequest
    {
        [Required]
        public int PatientId { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Modality { get; set; } = string.Empty;

        public DateTime StudyDate { get; set; }

        [MaxLength(20)]
        public string Status { get; set; } = string.Empty;
    }
}
