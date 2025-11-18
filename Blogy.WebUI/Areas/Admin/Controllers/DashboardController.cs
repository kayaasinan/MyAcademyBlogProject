using Blogy.Business.Services.BlogServices;
using Blogy.WebUI.Consts;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    [Area(Roles.Admin)]
    public class DashboardController(IBlogService _blogService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var writer = await _blogService.TGetLastWriterNameAsync();
            ViewBag.LastWriter = writer;
            return View();
        }
        public async Task<IActionResult> GetStatusChart()
        {
            return Json(await _blogService.TGetStatusCountsAsync());
        }
        public async Task<IActionResult> GetCategoryChart()
        {
            return Json(await _blogService.TGetCategoryCountsAsync());
        }
    }
}
