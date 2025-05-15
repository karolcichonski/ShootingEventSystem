using ShootingEventSystemWebAPI.Entities;
using System.ComponentModel.DataAnnotations;

namespace ShootingEventSystemWebAPI.Models
{
    public class CreateClubDto
    {
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        public int AddressId { get; set; }
    }
}
