using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISStudyAbroad2023.Models
{
    public class Thought
    {
        [Key]
        [Required]
        public int ThoughtId { get; set; }

        [Required]
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student? Person { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ThoughtDate { get; set; }
    }
}
