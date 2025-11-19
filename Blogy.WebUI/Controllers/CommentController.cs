using Blogy.Business.DTOs.CommentDtos;
using Blogy.Business.Services.CommentServices;
using Blogy.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
            if (dto.Status == CommentStatus.AutoBlocked)
            {
                TempData["CommentMessage"] = "Bu yorum uygunsuz içerik içerdiği için engellendi.";
                TempData["CommentClass"] = "alert-danger";
            }
            else if (dto.Status == CommentStatus.Review)
            {
                TempData["CommentMessage"] = "Yorumunuz kontrol için işleme alındı.";
                TempData["CommentClass"] = "alert-warning";
            }
            else if (dto.Status == CommentStatus.Rejected)
            {
                TempData["CommentMessage"] = "Yorumunuz uygun bulunmadı ve reddedildi.";
                TempData["CommentClass"] = "alert-danger";
            }
            else
            {
                TempData["CommentMessage"] = "Yorum başarıyla eklendi!";
                TempData["CommentClass"] = "alert-success";
            }
            return RedirectToAction("BlogDetails", "Blog", new { id = dto.BlogId });
        }
    }
}
