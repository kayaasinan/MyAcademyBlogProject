using Blogy.Business.Services.CommentServices;
using Blogy.Entity.Entities;
using Blogy.WebUI.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blogy.WebUI.Areas.Member.Controllers
{
    [Area(Roles.Member)]
    [Authorize(Roles = Roles.Member)]
    public class MemberCommentController(ICommentService _commentService,UserManager<AppUser> _userManager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var comments = await _commentService.TGetCommentsByUserAsync(user.Id);
            return View(comments);
        }
    }
}
