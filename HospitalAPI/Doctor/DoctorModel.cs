using System.ComponentModel.DataAnnotations;

namespace HospitalAPI.Doctor
{
    public class DoctorModel
    {
        [Key]
        public int DoctorId { get; set; }

        public int PersonId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Specialty { get; set; } = string.Empty;

        public Person.PersonModel Person { get; set; } = null!;
        public ICollection<Study.StudyModel> Studies { get; set; } = new List<Study.StudyModel>();
    }
}
