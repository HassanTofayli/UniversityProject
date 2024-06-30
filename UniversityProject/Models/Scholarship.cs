using System.ComponentModel.DataAnnotations;

namespace UniversityProject.Models
{
    public class Scholarship
    {
        [Key]
        public int ScholarshipId { get; set; }

        public int UniversityId { get; set; }
        public University University { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public decimal Amount { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
