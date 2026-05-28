using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Diplom.Data;
using Diplom.Models;
using Microsoft.AspNetCore.Authorization;

namespace Diplom.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var stacks = await _context.WoodStacks.ToListAsync();

            // Последние 10 движений
            var recentMovements = await _context.WoodMovements
                .Include(m => m.WoodStack)
                .OrderByDescending(m => m.MovementDate)
                .Take(10)
                .ToListAsync();

            // Приход за сегодня
            var today = DateTime.Today;
            var todayIncome = await _context.WoodMovements
                .Where(m => m.MovementType == "Income" && m.MovementDate.Date == today)
                .SumAsync(m => (decimal?)m.Volume) ?? 0;

            ViewBag.RecentMovements = recentMovements;
            ViewBag.TodayIncome = todayIncome;

            return View(stacks);
        }
    }
}