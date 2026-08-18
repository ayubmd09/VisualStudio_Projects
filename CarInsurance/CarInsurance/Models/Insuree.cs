using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarInsurance.Models
{
    public class Insuree
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; } 

        [Required]
        public int CarYear { get; set; } 

        [Required]
        public string CarMake { get; set; } = string.Empty;

        [Required]
        public string CarModel { get; set; } = string.Empty;

        [Required]
        public bool DUI { get; set; }

        [Required]
        public int SpeedingTickets { get; set; }

        [Required]
        public string CoverageType { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Quote { get; set; }
    }
}