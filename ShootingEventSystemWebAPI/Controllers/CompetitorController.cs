using Microsoft.AspNetCore.Mvc;
using ShootingEventSystemWebAPI.Models;
using ShootingEventSystemWebAPI.Services;

namespace ShootingEventSystemWebAPI.Controllers
{
    [ApiController]
    [Route("api/competitor")]
    public class CompetitorController:ControllerBase
    {
        private readonly ICompetitorService _competitorService;

        public CompetitorController(ICompetitorService competitorService)
        {
            _competitorService = competitorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompetitorDto>>> GetAllAsync()
        {
            var competitors = await _competitorService.GetAllCompetitorsAsync();
            return Ok(competitors);
        }

        [HttpGet("ById")]
        public ActionResult<CompetitorDto> GetById([FromQuery] int id)
        {
            var competitor = _competitorService.GetById(id);
            if (competitor == null)
            {
                return NotFound();
            }
            return Ok(competitor);
        }

        [HttpGet("ByUserId")]
        public ActionResult<CompetitorDto> GetByUserId([FromQuery] int userId)
        {
            var competitor = _competitorService.GetByUserId(userId);
            if (competitor == null)
            {
                return NotFound();
            }
            return Ok(competitor);
        }

        [HttpPost]
        public ActionResult<int> CreateCompetitor([FromBody] CreateCompetitorDto competitorDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var id = _competitorService.CreateCompetitor(competitorDto);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }
    }
}
