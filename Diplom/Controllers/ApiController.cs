using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Diplom.Data;

namespace Diplom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("stacks")]
        public async Task<IActionResult> GetStacks()
        {
            var stacks = await _context.WoodStacks
                .Select(s => new { s.WoodType, s.CurrentVolume })
                .ToListAsync();
            return Ok(stacks);
        }
    }
}