using System.ComponentModel.DataAnnotations;

namespace HospitalAPI.Patient
{
    public class PatientModel
    {
        [Key]
        public int PatientId { get; set; }

        public int PersonId { get; set; }

        [Required]
        [MaxLength(50)]
        public string MRN { get; set; } = string.Empty;

        [MaxLength(20)]
        public string Status { get; set; } = string.Empty;

        public Person.PersonModel Person { get; set; } = null!;
        public ICollection<Study.StudyModel> Studies { get; set; } = new List<Study.StudyModel>();
    }
}
