using Microsoft.AspNetCore.Mvc;
using ShootingEventSystemWebAPI.Models;
using ShootingEventSystemWebAPI.Services;

namespace ShootingEventSystemWebAPI.Controllers
{
    [Route("api/arbiter")]
    public class ArbiterController:ControllerBase
    {
        private readonly IArbiterService _arbiterService;
        public ArbiterController(IArbiterService arbiterService)
        {
            _arbiterService = arbiterService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArbiterDto>>> GetAllArbitersAsync()
        {
            var arbiters = await _arbiterService.GetAllArbitersAsync();
            return Ok(arbiters);
        }

        [HttpGet("ById")]
        public ActionResult<ArbiterDto> GetById([FromQuery] int id)
        {
            var arbiter = _arbiterService.GetById(id);
            if (arbiter == null)
            {
                return NotFound();
            }
            return Ok(arbiter);
        }

        [HttpGet("ByUserId")]

        public ActionResult<ArbiterDto> GetByUserId([FromQuery] int userId)
        {
            var arbiter = _arbiterService.GetByUserId(userId);
            if (arbiter == null)
            {
                return NotFound();
            }
            return Ok(arbiter);
        }

        [HttpPost]
        public ActionResult<int> CreateArbiter([FromBody] CreateArbiterDto arbiterDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var id = _arbiterService.CreateArbiter(arbiterDto);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }
    }
}
