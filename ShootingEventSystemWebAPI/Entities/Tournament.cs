namespace ShootingEventSystemWebAPI.Entities
{
    public class Tournament
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime StartDateTime { get; set; }
        public int CompetitionId { get; set; }
        public virtual Competition Competition {  get; set; }
        public virtual List<Competitor> Competitors { get; set; }
        public int MaxCompetitorsCount { get; set; }
        public virtual List<Arbiter> Arbiters { get; set; }
        public virtual List<Result> Results { get; set; }
        public bool IsVisible { get; set; }
        public bool IsSignUpOpen { get; set; }
        public bool IsFinished { get; set; }
    }
}
