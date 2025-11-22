using Blogy.Business.DTOs.TagDtos;
using Blogy.Business.Services.TagServices;
using Blogy.WebUI.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    [Area(Roles.Admin)]
    [Authorize(Roles = $"{Roles.Admin}")]
    public class TagController(ITagService _tagService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var tags = await _tagService.GetAllAsync();
            return View(tags);
        }
        public async Task<IActionResult> UpdateTag(int id)
        {
            var tag = await _tagService.GetByIdAsync(id);
            return View(tag);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTag(UpdateTagDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            await _tagService.UpdateAsync(dto);
            return RedirectToAction(nameof(Index));
        }
    }
}
