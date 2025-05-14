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
        public ActionResult<List<UserDto>> GetAllUsers()
        {
            List<UserDto> userDtos = _userService.GetAllUsers().ToList();
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

        [HttpGet]
        [Route("email")]
        public ActionResult<UserDto> GetByEmail([FromQuery] string email)
        {
            var user = _userService.GetByEmail(email);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}
