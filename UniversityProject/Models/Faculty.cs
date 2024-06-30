using System.ComponentModel.DataAnnotations;

namespace UniversityProject.Models
{
    public class Faculty
    {
        [Key]
        public int FacultyId { get; set; }

        public int UniversityId { get; set; }
        public University University { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(15)]
        [RegularExpression(@"\+\d{1,3}-\d{1,4}-\d{1,4}-\d{4}")]
        public string Phone { get; set; }

        public List<Course> Courses { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }

}
