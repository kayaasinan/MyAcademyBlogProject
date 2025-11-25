using Blogy.Business.DTOs.UserDTOs;
using Blogy.Business.Services.GoogleServices;
using Blogy.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Controllers
{
    public class LoginController(SignInManager<AppUser> _signInManager,IRecaptchaService _recaptchaService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);
            bool response = await _recaptchaService.VerifyAsync(dto.RecaptchaToken);
            if (!response)
            {
                ModelState.AddModelError("", "Robot doğrulaması başarısız!");
                return View(dto);
            }
            var result = await _signInManager.PasswordSignInAsync(dto.UserName, dto.Password, false, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı adı veya şifre hatalı");
                return View(dto);
            }
            TempData["CaptchaSuccess"] = true;
            return RedirectToAction("Index", "Default");
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Default");
        }
    }
}

