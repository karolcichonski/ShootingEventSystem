using ShootingEventSystemWebAPI.Entities;

namespace ShootingEventSystemWebAPI.Models
{
    public class CreateTournamentDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime StartDateTime { get; set; }
        public int CompetitionId { get; set; }
        public int MaxCompetitorsCount { get; set; }
    }
}
