using EasyIntern.Context;
using EasyIntern.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyIntern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly InternContext _context;

        public AccountsController(InternContext context)
        {
            _context = context;
        }
        [HttpGet("login")]
        public async Task<IActionResult> Login(InternLoginModel login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("user name and password required");
            }
            var intern = await _context.Interns.FirstOrDefaultAsync(x => x.UserName == login.UserName);
            if (intern == null) return BadRequest("user name or password may be wrong");
            var successful = BCrypt.Net.BCrypt.Verify(login.Password, intern.PasswordHash);
            if (successful)
            {
                return Ok(new LoginSuccessDto
                {
                    FirstName = intern.FirstName,
                    LastName = intern.LastName,
                    UserName=intern.UserName
                });

            }
            return BadRequest("user name or password may be wrong");
        }

       [HttpGet("organisationLogin")] public async Task<IActionResult> OrganisationLogin(OrganisationLoginModel login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("user name and password required");
            }
            var organisationUsers = await _context.OrganisationUsers.Include(x=>x.Organisation).FirstOrDefaultAsync(x => x.UserName == login.UserName);
            if (organisationUsers == null) return BadRequest("user name or password may be wrong");
            var successful = BCrypt.Net.BCrypt.Verify(login.Password, organisationUsers.PasswordHash);
            if (successful)
            {
                return Ok(new LoginSuccessDto
                {
                    FirstName = organisationUsers.FirstName,
                    LastName = organisationUsers.LastName,
                    UserName = organisationUsers.UserName,
                    OrganisationName = organisationUsers.Organisation.Name,
                });

            }
            return BadRequest("user name or password may be wrong");
        }
    }

    public class LoginSuccessDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string OrganisationName { get; set; }
    }
}