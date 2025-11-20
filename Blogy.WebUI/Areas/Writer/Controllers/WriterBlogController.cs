using Blogy.Business.DTOs.BlogDtos;
using Blogy.Business.Services.BlogServices;
using Blogy.Business.Services.CategoryServices;
using Blogy.Entity.Entities;
using Blogy.WebUI.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blogy.WebUI.Areas.Writer.Controllers
{
    [Area(Roles.Writer)]
    [Authorize(Roles = $"{Roles.Writer}")]
    public class WriterBlogController(IBlogService _blogService, ICategoryService _categoryService, UserManager<AppUser> _userManager) : Controller
    {
        private async Task GetCategories()
        {
            var categories = await _categoryService.GetAllAsync();

            ViewBag.categories = (from category in categories
                                  select new SelectListItem
                                  {
                                      Text = category.CategoryName,
                                      Value = category.Id.ToString()
                                  }).ToList();
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var blogs = await _blogService.TGetBlogsByWriterIdAsync(user.Id);
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

            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            blogDto.WriterId = user.Id;

            await _blogService.CreateAsync(blogDto);

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> UpdateBlog(int id)
        {
            await GetCategories();
            var category = await _blogService.GetByIdAsync(id);
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
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            blogDto.WriterId = user.Id;

            await _blogService.UpdateAsync(blogDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
