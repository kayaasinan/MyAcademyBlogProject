using Blogy.Business.DTOs.CommentDtos;
using Blogy.Business.Services.BlogServices;
using Blogy.Business.Services.CommentServices;
using Blogy.Entity.Entities;
using Blogy.WebUI.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    [Area(Roles.Admin)]
    [Authorize(Roles = $"{Roles.Admin}")]
    public class CommentController(ICommentService _commentService, IBlogService _blogService, UserManager<AppUser> _userManager) : Controller
    {
        private async Task GetBlogs()
        {
            var blogs = await _blogService.GetAllAsync();
            ViewBag.Blogs = (from blog in blogs
                             select new SelectListItem
                             {
                                 Text = blog.Title,
                                 Value = blog.Id.ToString()
                             }).ToList();
        }
        public async Task<IActionResult> Index()
        {
            var comments = await _commentService.GetCommentsByAccepted();
            return View(comments);
        }
        public async Task<IActionResult> CreateComment()
        {
            await GetBlogs();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentDto dto)
        {
            await GetBlogs();
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            dto.UserId = user.Id;
            await _commentService.CreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }
    }
}
