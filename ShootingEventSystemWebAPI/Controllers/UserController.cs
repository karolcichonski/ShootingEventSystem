using Microsoft.AspNetCore.Mvc;
using ShootingEventSystemWebAPI.Entities;
using ShootingEventSystemWebAPI.Models;
using ShootingEventSystemWebAPI.Services;

namespace ShootingEventSystemWebAPI.Controllers
{
    [Route("api/user")]
    public class UserController:ControllerBase
    {
        IUserService _userService;
        public UserController(IUserService userService) 
        { 
            _userService = userService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsersAsync()
        {
            IEnumerable<UserDto> userDtos = await _userService.GetAllUsersAsync();
            return Ok(userDtos);
        }

        [HttpGet("ById")]
        public ActionResult<UserDto> GetById([FromQuery]int id)
        {
            var user = _userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("ByEmail")]
        public ActionResult<UserDto> GetByEmail([FromQuery] string email)
        {
            var user = _userService.GetByEmail(email);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public ActionResult<int> CreateUser([FromBody] CreateUserDto CreateUserDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var id = _userService.CreateUser(CreateUserDto);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }
    }
}
