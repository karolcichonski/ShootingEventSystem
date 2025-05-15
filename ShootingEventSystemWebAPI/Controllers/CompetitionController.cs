using Microsoft.AspNetCore.Mvc;
using ShootingEventSystemWebAPI.Models;
using ShootingEventSystemWebAPI.Services;

namespace ShootingEventSystemWebAPI.Controllers
{
    [ApiController]
    [Route("api/competition")]
    public class CompetitionController:ControllerBase
    {
        private readonly ICompetitionService _competitionService;
        public CompetitionController(ICompetitionService competitionService) 
        {
            _competitionService = competitionService;
        }

        [HttpGet]
        public IActionResult GetAllCompetitions()
        {
            var competitions = _competitionService.GetAllCompetitions();
            return Ok(competitions);
        }

        [HttpPost]
        public IActionResult CreateCompetition([FromBody] CreateCompetitionDto competitionDto)
        {
            if (competitionDto == null)
            {
                return BadRequest("Invalid data.");
            }

            var competitionId = _competitionService.CreateCompetition(competitionDto);
            return CreatedAtAction(nameof(GetById), new { id = competitionId }, competitionId);
        }

        [HttpGet("ById")]
        public IActionResult GetById([FromQuery]int id)
        {
            var competition = _competitionService.GetById(id);
            if (competition == null)
            {
                return NotFound();
            }
            return Ok(competition);
        }

        [HttpGet("ByName")]
        public IActionResult GetByName([FromQuery] string name)
        {
            var competition = _competitionService.GetByName(name);
            if (competition == null)
            {
                return NotFound();
            }
            return Ok(competition);
        }
    }
}
