using Microsoft.AspNetCore.Mvc;
using ShootingEventSystemWebAPI.Models;
using ShootingEventSystemWebAPI.Services;

namespace ShootingEventSystemWebAPI.Controllers
{
    [ApiController]
    [Route("api/result")]
    public class ResultController:ControllerBase
    {
        private readonly IResultService _resultService;
        public ResultController(IResultService resultService)
        {
            _resultService = resultService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResultDto>>> GetAllAsync()
        {
            var results = await _resultService.GetAllResultsAsync();
            return Ok(results);
        }

        [HttpGet("ById")]
        public ActionResult<ResultDto> GetById([FromQuery] int id)
        {
            var result = _resultService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("FromTournament")]
        public ActionResult<List<ResultDto>> GetResultsFromTournament([FromQuery] int tournamentId, [FromQuery] int competitorId)
        {
            var results = _resultService.GetResultsFromTournament(tournamentId, competitorId);
            if (results == null)
            {
                return NotFound();
            }
            return Ok(results);
        }

        [HttpPost]
        public ActionResult<int> CreateResult([FromBody] CreateResultDto resultDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var id = _resultService.CreateResult(resultDto);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }
    }
}
