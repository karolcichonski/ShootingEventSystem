using ShootingEventSystemWebAPI.Entities;

namespace ShootingEventSystemWebAPI.Models
{
    public class ResultDto
    {
        public int Id { get; set; }
        public int CompetitorId { get; set; }
        public int ArbiterId { get; set; }
        public int TournamentId { get; set; }
        public decimal Score { get; set; }
        public decimal PenaltyPoints { get; set; }
        public bool IsDisqualified { get; set; }
    }
}
