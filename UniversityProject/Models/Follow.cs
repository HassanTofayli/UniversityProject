using System.ComponentModel.DataAnnotations;

namespace UniversityProject.Models
{
    public class Follow
    {
        [Key]
        public int FollowId { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int UniversityId { get; set; }
        public University University { get; set; }

        public DateTime FollowDate { get; set; }
    }

}
