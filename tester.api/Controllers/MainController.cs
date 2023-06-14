using Microsoft.AspNetCore.Mvc;
using tester.api.Infrastructure.Managers.Main;

namespace tester.api.Controllers
{
    [ApiController]
    [Route("main")]
    public class MainController : ControllerBase
    {
        [HttpGet]
        [Route("get/flag")]
        public async Task<IActionResult> GetFlaggerRound([FromQuery] int? round, [FromQuery] int? difficulty, [FromQuery] string? prevFlag)
        {
            try
            {
                var result = await new MainManager().GetFlaggerRound(round, difficulty, prevFlag);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("get/language")]
        public async Task<IActionResult> GetLanggerRound([FromQuery] int? round, [FromQuery] int? difficulty, [FromQuery] string? prevLang)
        {
            try
            {
                var result = await new MainManager().GetFlaggerRound(round, difficulty, prevLang);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
