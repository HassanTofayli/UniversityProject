using System.ComponentModel.DataAnnotations;

namespace UniversityProject.ViewModels
{
    public class EditUserViewModel
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Role")]
        public string SelectedRole { get; set; }
        public List<string> Roles { get; set; } = new List<string> { "Admin", "Doctor", "Patient" };
    }
}
