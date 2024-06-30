using UniversityProject.Models;

namespace UniversityProject.ViewModels
{
    public class UniversityDetailsViewModel
    {
        public University University { get; set; }
        public List<Department> Departments { get; set; }
        public List<Course> Courses { get; set; }
        public List<Faculty> Faculties { get; set; }
    }
}
