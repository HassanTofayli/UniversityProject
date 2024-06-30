using System.ComponentModel.DataAnnotations;

namespace UniversityProject.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        public int UniversityId { get; set; }
        public University University { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime PostedDate { get; set; }

        public List<Reaction> Reactions { get; set; }
    }

}
