using tester.api.Helpers;
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
        [Route("get/countries")]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                var result = await new MainManager().GetCountries();
                var countries = CustomHelpers.ReturnCountries(result);
                return Ok(countries);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
