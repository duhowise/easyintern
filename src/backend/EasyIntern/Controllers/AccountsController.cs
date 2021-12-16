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
        public Task<IActionResult> Login(InternLoginModel login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("user name and password required");
            }
        }

       [HttpGet("organisationLogin")] public Task<IActionResult> OrganisationLogin(OrganisationLoginModel login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("user name and password required");
            }
        }
    }
}