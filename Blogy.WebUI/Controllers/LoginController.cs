using Blogy.Business.DTOs.UserDTOs;
using Blogy.Entity.Entities;
using Blogy.WebUI.Consts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);
            var result = await _signInManager.PasswordSignInAsync(dto.UserName, dto.Password, false, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı adı veya şifre hatalı");
                return View(dto);
            }
            var user = await _userManager.FindByNameAsync(dto.UserName);
            var roles = await _userManager.GetRolesAsync(user);

            if (roles.Contains(Roles.Admin))
                return RedirectToAction("Index", "Profile", new { area = "Admin" });

            if (roles.Contains(Roles.Writer))
                return RedirectToAction("Index", "WriterProfile", new { area = "Writer" });

            return RedirectToAction("Index", "MemberProfile", new { area = "Member" });
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Default");
        }
    }
}

