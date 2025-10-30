using AutoMapper;
using Blogy.Business.DTOs.UserDTOs;
using Blogy.Entity.Entities;
using Blogy.WebUI.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    [Area(Roles.Admin)]
    [Authorize(Roles=Roles.Admin)]
    public class UsersController(UserManager<AppUser> _userManager, IMapper _mapper, RoleManager<AppRole> _roleManager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();

            var mappedUses = _mapper.Map<List<ResultUserDto>>(users);
            foreach (var user in users)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                mappedUses.Find(x => x.Id == user.Id).Roles = userRoles;
            }
            return View(mappedUses);
        }
        public async Task<IActionResult> AssingRole(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            ViewBag.fullName = user.FirstName + "" + user.LastName;
            var roles = _roleManager.Roles.ToList();
            var userRoles = await _userManager.GetRolesAsync(user);
            var assingnRoleDto = new List<AssignRoleDto>();
            foreach (var role in roles)
            {
                assingnRoleDto.Add(new AssignRoleDto
                {
                    RoleId = role.Id,
                    RoleName = role.Name,
                    UserId = user.Id,
                    RoleExists = userRoles.Contains(role.Name)
                });

            }
            return View(assingnRoleDto);
        }
        [HttpPost]
        public async Task<IActionResult> AssingRole(List<AssignRoleDto> dto)
        {
            var userId=dto.Select(x=>x.UserId).FirstOrDefault();
            var users = await _userManager.FindByIdAsync(userId.ToString());
            foreach (var item in dto)
            {
                if (item.RoleExists)
                {
                    await _userManager.AddToRoleAsync(users, item.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(users, item.RoleName);
                }
            }
            return RedirectToAction("Index");
        }
    }
}
