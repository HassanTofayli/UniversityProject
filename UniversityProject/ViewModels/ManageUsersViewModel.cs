namespace UniversityProject.ViewModels
{
    public class ManageUsersViewModel
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public IList<string> Roles { get; set; }
    }
}
