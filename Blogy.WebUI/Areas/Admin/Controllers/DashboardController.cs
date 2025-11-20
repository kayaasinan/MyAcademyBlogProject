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
            ViewBag.LastWriter = await _blogService.TGetLastWriterNameAsync();
            ViewBag.TotalBlogs = await _blogService.TGetTotalBlogCountAsync();
            var mostCommented = await _blogService.TGetMostCommentedBlogAsync();
            ViewBag.MostCommentedTitle = mostCommented?.Title ?? "Henüz yorum yok";
            ViewBag.MostCommentedCount = mostCommented?.Comments.Count ?? 0;
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
