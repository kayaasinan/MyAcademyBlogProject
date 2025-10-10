using AutoMapper;
using Blogy.Business.DTOs.BlogDtos;
using Blogy.Business.Services.BlogServices;
using Blogy.DataAccess.Repositories.BlogRepositories;
using Blogy.DataAccess.Repositories.CategoryRepositories;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController(IBlogService _blogService) : Controller
    {
  
        public async Task<IActionResult> Index()
        {
            var blogs = await _blogService.GetBlogsWithCategoriesAsync();
            return View(blogs);
        }
        public IActionResult CreateBlog()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogDto blogDto)
        {
            if (!ModelState.IsValid) return View(blogDto);
           
            await _blogService.CreateAsync(blogDto);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> UpdateBlog(int id)
        {
            var category= await _blogService.GetByIdAsync(id);
            return View(category);
        }
        public async Task<IActionResult> UpdateBlog(UpdateBlogDto blogDto)
        {
            if (ModelState.IsValid) return View(blogDto);

            await _blogService.UpdateAsync(blogDto);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> DeleteBlog(int id)
        {
            await _blogService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
