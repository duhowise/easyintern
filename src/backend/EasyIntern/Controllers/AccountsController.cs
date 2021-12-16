using EasyIntern.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyIntern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        [HttpGet("login")]
        public async Task<IActionResult> Login(InternLoginModel login)
        {
            await Task.CompletedTask;
            if (!ModelState.IsValid)
            {
                return BadRequest("user name and password required");
            }

            return Ok();
        }

       [HttpGet("organisationLogin")] public async Task<IActionResult> OrganisationLogin(OrganisationLoginModel login)
        {
            await Task.CompletedTask;
            if (!ModelState.IsValid)
            {
                return BadRequest("user name and password required");
            }

            return Ok();
        }
    }
}