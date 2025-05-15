using System.ComponentModel.DataAnnotations;

namespace ShootingEventSystemWebAPI.Models
{
    public class CreateResultDto
    {
        [Required]
        public int CompetitorId { get; set; }
        [Required]
        public int ArbiterId { get; set; }
        [Required]
        public int TournamentId { get; set; }
        [Required]
        public decimal Score { get; set; }
        public decimal PenaltyPoints { get; set; }
        public bool IsDisqualified { get; set; }
    }
}
