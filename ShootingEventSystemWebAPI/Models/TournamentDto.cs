using ShootingEventSystemWebAPI.Entities;

namespace ShootingEventSystemWebAPI.Models
{
    public class TournamentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime StartDateTime { get; set; }
        public int CompetitionId { get; set; }
        public string CompetitionName { get; set; }
        public List<CompetitorDto> Competitors { get; set; }
        public int MaxCompetitorsCount { get; set; }
        public List<ArbiterDto> Arbiters { get; set; }
        public List<ResultDto> Results { get; set; }
        public bool IsVisible { get; set; }
        public bool IsSignUpOpen { get; set; }
        public bool IsFinished { get; set; }
    }
}
