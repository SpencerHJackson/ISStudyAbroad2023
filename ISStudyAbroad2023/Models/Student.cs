using System.ComponentModel.DataAnnotations;

namespace ISStudyAbroad2023.Models
{
    public class Student
    {
        [Key]
        [Required]
        public int StudentId { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }

        public DateTime? LastCheckin { get; set; }

    }
}
