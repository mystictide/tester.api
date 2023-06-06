using Microsoft.AspNetCore.Mvc;
using tester.api.Infrastructure.Models.Main;
using tester.api.Infrastructure.Managers.CMS;

namespace tester.api.Controllers
{
    [ApiController]
    [Route("cms")]
    public class CMSController : ControllerBase
    {
        [HttpPost]
        [Route("manage/flag")]
        public async Task<IActionResult> ManageFlag([FromBody] Flags entity)
        {
            try
            {
                var result = await new CMSManager().ManageFlag(entity);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
