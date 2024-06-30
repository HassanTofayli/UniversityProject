using System.ComponentModel.DataAnnotations;

namespace UniversityProject.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        public int UniversityId { get; set; }
        public University University { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime EventDate { get; set; }

        [StringLength(100)]
        public string Location { get; set; }
    }

}
