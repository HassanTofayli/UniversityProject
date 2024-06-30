using System.ComponentModel.DataAnnotations;

namespace UniversityProject.Models
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }

        public int UniversityId { get; set; }
        public University University { get; set; }

        [Required]
        [StringLength(100)]
        public string Street { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string State { get; set; }

        [StringLength(10)]
        public string PostalCode { get; set; }

        [StringLength(50)]
        public string Country { get; set; }
    }

}
