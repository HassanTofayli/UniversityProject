using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityProject.Models
{
    public class UniversityManager : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public int? UniversityId { get; set; } // Make UniversityId nullable

        [ForeignKey("UniversityId")]
        public University University { get; set; }

        public string SubRole { get; set; } // e.g., "StudentRegistrar", "FacultyManager"
    }
}