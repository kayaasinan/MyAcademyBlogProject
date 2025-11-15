using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Member.Controllers
{
    public class MemberLayoutController : Controller
    {
        public IActionResult Layout()
        {
            return View();
        }
    }
}
