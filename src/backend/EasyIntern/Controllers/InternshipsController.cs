using EasyIntern.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyIntern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InternshipsController : ControllerBase
    {
        private readonly InternContext _context;

        public InternshipsController(Context.InternContext context)
        {
            _context = context;
        }
        [HttpGet("availableInternships")]
        public async Task<IActionResult> AvailableInternships()
        {
            var availableInternships=await _context.InternshipAdvertisements.Where(x=>x.RemainingSlots>0).ToListAsync();
            return Ok(availableInternships);
        }
    }
}