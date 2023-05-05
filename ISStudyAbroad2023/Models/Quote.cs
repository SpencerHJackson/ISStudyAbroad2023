using System.ComponentModel.DataAnnotations;
namespace ISStudyAbroad2023.Models
{
    public class Quote
    {
        [Key]
        [Required]
        public int QuoteId { get; set; }

        [Required]
        public string QuoteAuthor { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.MultilineText)]
        public string QuoteText { get; set;} = string.Empty;
    }
}
