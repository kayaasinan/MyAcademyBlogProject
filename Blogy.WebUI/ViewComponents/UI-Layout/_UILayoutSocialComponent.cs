using Blogy.Business.Services.SocialServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blogy.WebUI.ViewComponents.UI_Layout
{
    public class _UILayoutSocialComponent(ISocialService _socialService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var socials = await _socialService.GetAllAsync();
            return View(socials);
        }
    }
}
