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
        public async Task<IActionResult> GetRandomFlag([FromQuery] int? difficulty)
        {
            try
            {
                var result = await new MainManager().GetRandomFlag(difficulty);
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
