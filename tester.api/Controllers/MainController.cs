using Microsoft.AspNetCore.Mvc;
using tester.api.Infrastructure.Managers.Main;

namespace tester.api.Controllers
{
    [ApiController]
    [Route("main")]
    public class MainController : ControllerBase
    {
        [HttpGet]
        [Route("get/profile")]
        public async Task<IActionResult> GetProfile([FromQuery] string username)
        {
            try
            {
                //var result = await new MainManager().GetProfile(username);
                return Ok("");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
