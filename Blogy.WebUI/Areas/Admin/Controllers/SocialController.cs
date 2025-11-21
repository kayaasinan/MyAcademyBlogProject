using Blogy.Business.DTOs.SocialDtos;
using Blogy.Business.Services.SocialServices;
using Blogy.WebUI.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    [Area(Roles.Admin)]
    [Authorize(Roles = $"{Roles.Admin}")]
    public class SocialController(ISocialService _socialService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var socials = await _socialService.GetAllAsync();
            return View(socials);
        }
        public async Task<IActionResult> UpdateSocial(int id)
        {
            var social = await _socialService.GetByIdAsync(id);
            return View(social);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateSocial(UpdateSocialDto updateSocial)
        {
            if (!ModelState.IsValid)
            {
                return View(updateSocial);
            }

            await _socialService.UpdateAsync(updateSocial);
            return RedirectToAction(nameof(Index));
        }
    }

}

