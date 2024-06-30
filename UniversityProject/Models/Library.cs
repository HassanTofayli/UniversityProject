using System.ComponentModel.DataAnnotations;

namespace UniversityProject.Models
{
    public class Library
    {
        [Key]
        public int LibraryId { get; set; }

        public int UniversityId { get; set; }
        public University University { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        public string Location { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }

}
