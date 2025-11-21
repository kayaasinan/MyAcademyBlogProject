using Blogy.Business.DTOs.AIDtos;
using Blogy.Business.Services.AIServices;
using Blogy.WebUI.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    [Area(Roles.Admin)]
    [Authorize(Roles = $"{Roles.Admin}")]
    public class AIArticleController(IAIService _aiService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(AIArticleDto dto)
        {
            var result = await _aiService.GenerateArticleAsync(dto);
            ViewBag.Article = result.content;
            return View();
        }
    }
}
