namespace ShootingEventSystemWebAPI.Entities
{
    public class Result
    {
        public int Id { get; set; }
        public int CompetitorId { get; set; }
        public virtual Competitor Competitor { get; set; }
        public int ArbiterId { get; set; }
        public virtual Arbiter Arbiter { get; set; }
        public int TournamentId { get; set; }
        public virtual Tournament Tournament { get; set; }
        public decimal Score { get; set; }
        public decimal PenaltyPoints { get; set; }
        public bool IsDisqualified { get; set; } 
    }
}
