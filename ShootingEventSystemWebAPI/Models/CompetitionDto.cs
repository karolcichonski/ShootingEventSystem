namespace ShootingEventSystemWebAPI.Models
{
    public class CompetitionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal MaxScore { get; set; }
    }
}
