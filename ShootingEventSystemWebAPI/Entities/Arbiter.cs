using Microsoft.AspNetCore.SignalR;

namespace ShootingEventSystemWebAPI.Entities
{
    public class Arbiter
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? LicenceNumber { get; set; }
        public virtual List<Tournament> Tournaments { get; set; }
        public bool IsActive { get; set; }

    }
}
