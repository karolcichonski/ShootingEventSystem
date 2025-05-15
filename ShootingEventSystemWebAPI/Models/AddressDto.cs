using ShootingEventSystemWebAPI.Entities;
using System.ComponentModel.DataAnnotations;

namespace ShootingEventSystemWebAPI.Models
{
    public class AddressDto
    {
        [Required]
        [MaxLength(50)]
        public string Country { get; set; }
        [Required]
        [MaxLength(50)]
        public string City { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        [Required]
        public string PostalCode { get; set; }
    }
}
