using ShootingEventSystemWebAPI.Entities;
using System.ComponentModel.DataAnnotations;

namespace ShootingEventSystemWebAPI.Models
{
    public class CreateCompetitorDto
    {
        [Required]
        public int UserId { get; set; }
        public string LicenceNumber { get; set; }
        [Required]
        public int ClubId { get; set; }
        public bool IsActive { get; set; }
    }
}
