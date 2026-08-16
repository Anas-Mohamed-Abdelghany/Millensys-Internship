using System.ComponentModel.DataAnnotations;

namespace HospitalAPI.Person
{
    public class PersonDTO
    {
        public int PersonId { get; set; }

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
    }
}
