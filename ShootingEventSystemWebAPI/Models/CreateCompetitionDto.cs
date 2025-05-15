using System.ComponentModel.DataAnnotations;

namespace ShootingEventSystemWebAPI.Models
{
    public class CreateCompetitionDto
    {
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public decimal MaxScore { get; set; }
    }
}
