using ShootingEventSystemWebAPI.Entities;
using System.ComponentModel.DataAnnotations;

namespace ShootingEventSystemWebAPI.Models
{
    public class CreateArbiterDto
    {
        [Required]
        public int UserId { get; set; }
        public string? LicenceNumber { get; set; }
        public bool IsActive  { get; set; }
    }
}
