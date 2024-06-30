using System.ComponentModel.DataAnnotations;

namespace UniversityProject.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } = "NoName";

        [Required]
        [StringLength(100)]
        public string? LastName { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [StringLength(15)]
        public string? Phone { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public int? CurrentUniversityId { get; set; }

        public University? CurrentUniversity { get; set; }

        public List<Follow> FollowedUniversities { get; set; } = new List<Follow>();

        public List<Reaction> Reactions { get; set; } = new List<Reaction>();

        public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

        public List<Notification> Notifications { get; set; } = new List<Notification>();

        public DateTime? CreatedDate { get; set; } = DateTime.Now;
    }
}
