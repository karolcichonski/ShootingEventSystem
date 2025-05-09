namespace ShootingEventSystemWebAPI.Entities
{
    public class Competitor
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public string LicenceNumber { get; set; }
        public int ClubId { get; set; }
        public virtual Club Club { get; set; }
        public virtual List<Tournament> Tournaments { get; set; }
        public bool IsActive { get; set; }
    }
}
