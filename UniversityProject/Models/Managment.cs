using System.ComponentModel.DataAnnotations;

namespace UniversityProject.Models
{
    public class Management
    {
        [Key]
        public int ManagementId { get; set; }

        public int? UniversityId { get; set; } // Make UniversityId nullable

        [StringLength(100)]
        public string? PresidentName { get; set; }

        [StringLength(100)]
        public string? DeanName { get; set; }

        [StringLength(100)]
        public string? VicePresidentName { get; set; }
    }

}
