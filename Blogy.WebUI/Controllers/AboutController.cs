using Blogy.Business.Services.AboutServices;
using Blogy.Business.Services.AIServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blogy.WebUI.Controllers
{
    public class AboutController(IAboutService _aboutService,IAIService aIService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var about = await _aboutService.GetAllAsync();
            var value = about.FirstOrDefault();
            return View(value);
        }
        public async Task<IActionResult> GenerateAiAbout()
        {
            var result = await aIService.GenerateAboutTextAsync();
            return Json(result);
        }
    }
}
