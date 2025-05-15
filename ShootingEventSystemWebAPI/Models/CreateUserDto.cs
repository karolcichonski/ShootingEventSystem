using System.ComponentModel.DataAnnotations;

namespace ShootingEventSystemWebAPI.Models
{
    public class CreateUserDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        [MaxLength(25)]
        public string Name { get; set; }
        [MaxLength(25)]
        public string Surname { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
