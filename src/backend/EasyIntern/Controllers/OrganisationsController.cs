using EasyIntern.Context;
using EasyIntern.Model;
using Microsoft.AspNetCore.Mvc;

namespace EasyIntern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganisationsController : ControllerBase
    {
        private readonly InternContext _context;

        public OrganisationsController(InternContext context)
        {
            _context = context;
        }
       [HttpPost("newadvertisement")] public async Task<IActionResult> NewAdvertisement(InternshipAdvertisement advertisement)
       {
           await Task.CompletedTask;
           _context.InternshipAdvertisements.Add(advertisement);
           return Ok();
       }
       [HttpPost("newInternship")] public async Task<IActionResult> NewInternship(InternshipAdvertisement advertisement)
       {
           await Task.CompletedTask;
           _context.InternshipAdvertisements.Add(advertisement);
           return Ok();
       }
    }
}
