using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Diplom.Data;
using Diplom.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Diplom.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsersController(ApplicationDbContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            return View(users);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Roles = _roleManager.Roles.Select(r => r.Name).ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string email, string password, string fullName, string position, string role)
        {
            // Сохраняем введённые данные для возврата на форму
            ViewBag.FormData = new { email, fullName, position, role };
            ViewBag.Roles = _roleManager.Roles.Select(r => r.Name).ToList();

            // Проверка всех полей
            if (string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(position) ||
                string.IsNullOrWhiteSpace(role))
            {
                TempData["Error"] = "Все поля обязательны для заполнения.";
                return View();
            }

            // Проверка уникальности email
            var existing = await _userManager.FindByEmailAsync(email);
            if (existing != null)
            {
                TempData["Error"] = "Пользователь с таким email уже существует.";
                return View();
            }

            var user = new AppUser
            {
                UserName = email,
                Email = email,
                FullName = fullName,
                Position = position
            };

            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                if (!string.IsNullOrEmpty(role) && await _roleManager.RoleExistsAsync(role))
                    await _userManager.AddToRoleAsync(user, role);
                TempData["Success"] = $"Пользователь {email} создан!";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var errors = string.Join("; ", result.Errors.Select(e => e.Description));
                TempData["Error"] = $"Ошибка: {errors}";
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> DeleteUser(string id)
        {
            if (string.IsNullOrEmpty(id))
                return RedirectToAction("Index");

            var user = await _userManager.FindByIdAsync(id);
            if (user != null && user.Email != "admin@plywood.local")
            {
                await _userManager.DeleteAsync(user);
                TempData["Success"] = "Пользователь удалён.";
            }
            else
            {
                TempData["Error"] = "Нельзя удалить администратора.";
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                TempData["Error"] = "Не указан идентификатор пользователя.";
                return RedirectToAction(nameof(Index));
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                TempData["Error"] = "Пользователь не найден.";
                return RedirectToAction(nameof(Index));
            }

            // Защита от удаления самого администратора
            if (user.Email == "admin@plywood.local")
            {
                TempData["Error"] = "Нельзя удалить главного администратора.";
                return RedirectToAction(nameof(Index));
            }

            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                TempData["Success"] = $"Пользователь {user.Email} удалён.";
            }
            else
            {
                var errors = string.Join("; ", result.Errors.Select(e => e.Description));
                TempData["Error"] = $"Ошибка при удалении: {errors}";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}