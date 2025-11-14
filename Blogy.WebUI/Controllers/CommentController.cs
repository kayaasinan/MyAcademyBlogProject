using Blogy.Business.DTOs.CommentDtos;
using Blogy.Business.Services.CommentServices;
using Blogy.Entity.Entities;
using Humanizer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blogy.WebUI.Controllers
{
    public class CommentController(UserManager<AppUser> _userManager,ICommentService _commentService) : Controller
    {
        public async Task<IActionResult> AddComment(CreateCommentDto dto)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Login");
            }
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            dto.UserId = user.Id;
            await _commentService.CreateAsync(dto);
            return RedirectToAction("BlogDetails", "Blog", new { id = dto.BlogId });
        }
    }
}
