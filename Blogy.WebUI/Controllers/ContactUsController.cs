using Blogy.Business.DTOs.ContactUsDtos;
using Blogy.Business.Services.ContactUsServices;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Controllers
{
    public class ContactUsController(IContactUsService _contactUsService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateContactUsDto dto)
        {
            await _contactUsService.CreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }
    }
}
