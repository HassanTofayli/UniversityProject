using System.ComponentModel.DataAnnotations;

namespace UniversityProject.Models
{
    public class Reaction
    {
        [Key]
        public int ReactionId { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public ReactionType Type { get; set; }

        public DateTime ReactionDate { get; set; }
    }

}
