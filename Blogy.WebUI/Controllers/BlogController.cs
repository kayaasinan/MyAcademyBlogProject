using Blogy.Business.DTOs.BlogDtos;
using Blogy.Business.Services.BlogServices;
using Blogy.Business.Services.CategoryServices;
using Blogy.Entity.Entities;
using Microsoft.AspNetCore.Mvc;
using PagedList.Core;

namespace Blogy.WebUI.Controllers
{
    public class BlogController(IBlogService _blogService, ICategoryService _categoryService) : Controller
    {
        public async Task<IActionResult> Index(int page = 1, int pageSize = 4)
        {
            var blogs = await _blogService.TGetBlogsByAccepted();

            var values = new PagedList<ResultBlogDto>(blogs.AsQueryable(), page, pageSize);

            return View(values);
        }
        public async Task<IActionResult> GetBlogsByCategory(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            ViewBag.categoryName = category.Name;
            var blogs = await _blogService.GetBlogsByCategoryIdAsync(id);
            return View(blogs);
        }
        public async Task<IActionResult> BlogDetails(int id)
        {
            var blog = await _blogService.GetSingleByIdAsync(id);
            ViewBag.name = blog.Writer.FullName;
            return View(blog);
        }
    }
}
