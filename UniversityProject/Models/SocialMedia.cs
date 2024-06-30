using System.ComponentModel.DataAnnotations;

namespace UniversityProject.Models
{
    public class SocialMedia
    {
        [Key]
        public int SocialMediaId { get; set; }

        public int? UniversityId { get; set; }

        [StringLength(100)]
        public string? Facebook { get; set; }

        [StringLength(100)]
        public string? Twitter { get; set; }

        [StringLength(100)]
        public string? LinkedIn { get; set; }

        [StringLength(100)]
        public string? Instagram { get; set; }
    }
}
