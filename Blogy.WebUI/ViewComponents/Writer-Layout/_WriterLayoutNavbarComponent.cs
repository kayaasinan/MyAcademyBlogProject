using Blogy.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blogy.WebUI.ViewComponents.Writer_Layout
{
    public class _WriterLayoutNavbarComponent(UserManager<AppUser> _userManager) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.fullName = user?.FirstName + " " + user?.LastName;
            ViewBag.image = user?.ImageUrl;
            return View();
        }
    }
}
