using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Member.Controllers
{
    public class MemberProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
