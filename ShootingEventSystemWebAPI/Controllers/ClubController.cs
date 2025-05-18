using Microsoft.AspNetCore.Mvc;
using ShootingEventSystemWebAPI.Models;
using ShootingEventSystemWebAPI.Services;

namespace ShootingEventSystemWebAPI.Controllers
{
    [ApiController]
    [Route("api/club")]
    public class ClubController:ControllerBase
    {
        private readonly IClubService _clubService;
        public ClubController(IClubService clubService)
        {
            _clubService = clubService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClubDto>>> GetAllClubsAsync()
        {
            var clubs = await _clubService.GetAllClubsAsync();
            return Ok(clubs);
        }

        [HttpGet("ById")]
        public ActionResult<ClubDto> GetById([FromQuery] int id)
        {
            var club = _clubService.GetById(id);
            if (club == null)
            {
                return NotFound();
            }
            return Ok(club);
        }

        [HttpGet("ByName")]
        public ActionResult<ClubDto> GetByName([FromQuery] string name)
        {
            var club = _clubService.GetByName(name);
            if (club == null)
            {
                return NotFound();
            }
            return Ok(club);
        }

        [HttpPost]
        public ActionResult<int> CreateClub([FromBody] CreateClubDto clubDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var id = _clubService.CreateClub(clubDto);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }
    }
}
