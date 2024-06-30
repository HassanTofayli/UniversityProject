using System.ComponentModel.DataAnnotations;

namespace UniversityProject.Models
{
    public class Notification
    {
        [Key]
        public int NotificationId { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime Date { get; set; }

        public bool IsRead { get; set; }
    }

}
