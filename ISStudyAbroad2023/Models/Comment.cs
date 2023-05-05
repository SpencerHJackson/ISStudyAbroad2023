using System.ComponentModel.DataAnnotations;

namespace ISStudyAbroad2023.Models
{
    public class Comment
    {
        [Required]
        [Key]
        public int CommentId { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string CommentText { get; set; } = string.Empty;
    }
}
