using System.ComponentModel.DataAnnotations;

namespace ISStudyAbroad2023.Models
{
    public class Student
    {
        [Key]
        [Required]
        public int StudentId { get; set; }
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;

        public DateTime? LastCheckin { get; set; }

    }
}
