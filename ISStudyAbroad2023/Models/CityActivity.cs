using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISStudyAbroad2023.Models
{
    public class CityActivity
    {
        [Key]
        [Required]
        public int CityActivityId { get; set; }

        [Required]
        public int CityId { get; set; }
        [ForeignKey("CityId")]
        public virtual City? City { get; set; }

        [Required]
        public string CityActivityName { get; set; } = string.Empty;

        public string? CityActivityLocation { get; set; }

        [DataType(DataType.MultilineText)]
        public string? CityActivityDescription { get; set; }

        public ICollection <Comment>? Comments { get; set; }
    }
}
