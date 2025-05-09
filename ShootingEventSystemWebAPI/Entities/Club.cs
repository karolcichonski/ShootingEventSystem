using System.Net;

namespace ShootingEventSystemWebAPI.Entities
{
    public class Club
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
        public virtual List<User> Users { get; set; }

    }
}
