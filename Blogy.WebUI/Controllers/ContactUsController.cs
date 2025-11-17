using Blogy.Business.DTOs.ContactUsDtos;
using Blogy.Business.Services.AIServices;
using Blogy.Business.Services.ContactUsServices;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Controllers
{
    public class ContactUsController(IAIService _aIService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index([FromBody] CreateContactUsDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Body))
                return BadRequest("Mesaj boş olamaz.");
            var aIMessage = await _aIService.GenerateReplyAsync(dto.Body);
            return Json(new
            {
                userMessage = dto.Body,
                aIMessage = aIMessage.content
            });
        }
    }
}
