using Microsoft.AspNetCore.Mvc;

namespace ShootingEventSystemWebAPI.Controllers
{
    [ApiController]
    [Route("api/test")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetDateTime()
        {
            return Ok(DateTime.Now);
        }
    }
}
