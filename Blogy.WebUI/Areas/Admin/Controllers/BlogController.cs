using AutoMapper;
using Blogy.Business.DTOs.BlogDtos;
using Blogy.Business.Services.BlogServices;
using Blogy.Business.Services.CategoryServices;
using Blogy.DataAccess.Repositories.BlogRepositories;
using Blogy.DataAccess.Repositories.CategoryRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController(IBlogService _blogService,ICategoryService _categoryService) : Controller
    {
        private async Task GetCategories()
        {
            var categories=await _categoryService.GetAllAsync();

            ViewBag.categories=(from  category in categories
                                select new SelectListItem
                                {
                                    Text=category.CategoryName,
                                    Value=category.Id.ToString()
                                }).ToList();
        }
  
        public async Task<IActionResult> Index()
        {
            var blogs = await _blogService.GetBlogsWithCategoriesAsync();
            return View(blogs);
        }
        public async Task<IActionResult> CreateBlog()
        {
            await GetCategories();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogDto blogDto)
        {
            if (!ModelState.IsValid)
            {
                await GetCategories();
                return View(blogDto);
            }
           
            await _blogService.CreateAsync(blogDto);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> UpdateBlog(int id)
        {
            await GetCategories();
            var category= await _blogService.GetByIdAsync(id);
            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBlog(UpdateBlogDto blogDto)
        {
            if (!ModelState.IsValid)
            {
                await GetCategories();
                return View(blogDto);
            } 

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
