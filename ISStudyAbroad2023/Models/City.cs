using System.ComponentModel.DataAnnotations;

namespace ISStudyAbroad2023.Models
{
    public class City
    {
        [Key]
        [Required]
        public int CityId { get; set; }

        [Required]
        public string CityName { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        public DateTime BeginDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
    }
}
