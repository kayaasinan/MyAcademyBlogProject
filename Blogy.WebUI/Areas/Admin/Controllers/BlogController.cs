using AutoMapper;
using Blogy.Business.Services.BlogServices;
using Blogy.DataAccess.Repositories.BlogRepositories;
using Blogy.DataAccess.Repositories.CategoryRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    public class BlogController(IBlogService _blogService) : Controller
    {
        [Area("Admin")]
        public async Task<IActionResult> Index()
        {
            var blogs = await _blogService.GetBlogsWithCategoriesAsync();
            return View(blogs);
        }
    }
}
