using ShootingEventSystemWebAPI.Entities;

namespace ShootingEventSystemWebAPI.Models
{
    public class CompetitorDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string LicenceNumber { get; set; }
        public int ClubId { get; set; }
        public virtual List<Tournament> Tournaments { get; set; }
        public bool IsActive { get; set; }
    }
}
