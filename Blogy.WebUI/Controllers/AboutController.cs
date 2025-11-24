using AutoMapper;
using Blogy.Business.DTOs.UserDTOs;
using Blogy.Business.Services.AboutServices;
using Blogy.Business.Services.AIServices;
using Blogy.Business.Services.BlogServices;
using Blogy.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blogy.WebUI.Controllers
{
    public class AboutController(IAboutService _aboutService, IAIService aIService, IMapper _mapper,UserManager<AppUser> _userManager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var about = await _aboutService.TGetAboutWithTeamAsync();
            return View(about);
        }
        public async Task<IActionResult> GenerateAiAbout()
        {
            var result = await aIService.GenerateAboutTextAsync();
            return Json(result);
        }
        public async Task<IActionResult> WriterDetails(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            var writerDto = _mapper.Map<ResultUserDto>(user);
            return View(writerDto);
        }
    }
}
