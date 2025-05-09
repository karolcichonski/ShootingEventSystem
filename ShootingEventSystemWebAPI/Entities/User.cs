namespace ShootingEventSystemWebAPI.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }
    }
}
