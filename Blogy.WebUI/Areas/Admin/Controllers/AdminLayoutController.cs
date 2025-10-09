using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Layout()
        {
            return View();
        }
    }
}
