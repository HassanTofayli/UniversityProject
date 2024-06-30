using System.ComponentModel.DataAnnotations;

namespace UniversityProject.Models
{
    public class University
    {
        [Key]
        public int UniversityId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(100)]
        public string Location { get; set; }

        [StringLength(100)]
        [EmailAddress]
        public string ContactEmail { get; set; }

        [StringLength(15)]
        public string ContactPhone { get; set; }

        public string? Website { get; set; } = String.Empty;

        public List<Certificate>? ProvidedCertificates { get; set; }

        public List<Post>? Posts { get; set; }

        public Address? Address { get; set; } = null;

        public List<Department>? Departments { get; set; }

        public List<Faculty>? Faculties { get; set; }

        public List<Event>? Events { get; set; }

        public List<Club>? Clubs { get; set; }

        public List<Library>? Libraries { get; set; }

        public List<Scholarship>? Scholarships { get; set; }

        public List<Follow>? Followers { get; set; }

        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public List<UniversityManager>? Managers { get; set; }
        public IEnumerable<Student>? Students { get; set; }
    }
}
