using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Writer.Controllers
{
    public class WriterLayoutController : Controller
    {
        public IActionResult Layout()
        {
            return View();
        }
    }
}
