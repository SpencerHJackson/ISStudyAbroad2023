using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISStudyAbroad2023.Models
{
    public class Comment
    {
        [Required]
        [Key]
        public int CommentId { get; set; }

        [Required]
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Student? Student { get; set;}

        [Required]
        [DataType(DataType.MultilineText)]
        public string CommentText { get; set; } = string.Empty;
    }
}
