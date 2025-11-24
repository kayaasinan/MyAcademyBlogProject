using AutoMapper;
using Blogy.Business.DTOs.UserDTOs;
using Blogy.Entity.Entities;
using Blogy.WebUI.Consts;
using Elfie.Serialization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    [Area(Roles.Admin)]
    public class ProfileController(UserManager<AppUser> _userManager, IMapper _mapper, SignInManager<AppUser> _signInManager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var editUser = _mapper.Map<EditProfileDto>(user);
            return View(editUser);
        }
        [HttpPost]
        public async Task<IActionResult> Index(EditProfileDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var passwordCorrect = await _userManager.CheckPasswordAsync(user, dto.CurrentPassword);
            if (!passwordCorrect)
            {
                ModelState.AddModelError("", "Girilen mecvut şifreniz hatalı..!");
                return View(dto);
            }
            if (dto.ImageFile is not null)
            {
                var currentDirectory = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(dto.ImageFile.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = Path.Combine(currentDirectory, "wwwroot/UserImages/", imageName);
                using var stream = new FileStream(saveLocation, FileMode.Create);
                await dto.ImageFile.CopyToAsync(stream);
                user.ImageUrl = "/UserImages/" + imageName;
            }
            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.Email = dto.Email;
            user.PhoneNumber = dto.PhoneNumber;
            user.UserName = dto.UserName;
            user.Title = dto.Title;
            user.Description = dto.Description;



            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Güncelleme esnasında bir hata oluştu..!");
                return View(dto);
            }
            await _signInManager.RefreshSignInAsync(user);
            return RedirectToAction("Index", "Profile", new { area = Roles.Admin });
        }
    }
}
