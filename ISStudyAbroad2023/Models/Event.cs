using System.ComponentModel.DataAnnotations;

namespace ISStudyAbroad2023.Models
{
    public class Event
    {
        [Key]
        [Required]
        public int EventId { get; set; }

        [Required]
        public string EventName { get; set; } = string.Empty;

        public bool IsRequired { get; set; }

        [Required]
        public DateTime DateAndTime { get; set; }

        [DataType(DataType.MultilineText)]
        public string? Details { get; set; }

        public ICollection<Student>? Students { get; set; }

        public ICollection<CityActivity>? CityActivities { get; set; }

        public ICollection<Comment>? Comments { get; set; }
    }
}
