using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityProject.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        public int UniversityId { get; set; }

        [ForeignKey("UniversityId")]
        public University University { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public List<Course> Courses { get; set; } = new List<Course>();

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public List<Instructor> Instructors { get; set; } = new List<Instructor>();
    }

}
