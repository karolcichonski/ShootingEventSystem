namespace ShootingEventSystemWebAPI.Entities
{
    public class Competition
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal MaxScore { get; set; }
    }
}
