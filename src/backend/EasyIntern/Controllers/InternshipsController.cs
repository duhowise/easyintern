using Microsoft.AspNetCore.Mvc;

namespace EasyIntern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InternshipsController : ControllerBase
    {
        [HttpGet("availableInternships")]
        public async Task<IActionResult> AvailableInternships()
        {
            await Task.CompletedTask;
            return Ok();
        }
    }
}