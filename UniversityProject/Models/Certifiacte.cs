using System.ComponentModel.DataAnnotations;

namespace UniversityProject.Models
{
    public class Certificate
    {
        [Key]
        public int CertificateId { get; set; }

        public int UniversityId { get; set; }
        public University University { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }

}
