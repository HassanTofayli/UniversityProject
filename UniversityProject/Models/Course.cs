using System.ComponentModel.DataAnnotations;

namespace UniversityProject.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Description { get; set; }
        public List<Enrollment>? Enrollments { get; set; }

        public int Credits { get; set; }

        public DateTime? CreatedDate { get; set; } = DateTime.Now;

    }

}
