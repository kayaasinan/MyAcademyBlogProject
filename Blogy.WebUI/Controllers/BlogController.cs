using Blogy.Business.Services.BlogServices;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Controllers
{
    public class BlogController(IBlogService _blogService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetBlogsByCategory(int id)
        {
            var blogs = await _blogService.GetBlogsByCategoryIdAsync(id);
            return View(blogs);
        }
    }
}
