using Blogy.WebUI.Consts;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Writer.Controllers
{
    [Area(Roles.Writer)]
    public class WriterProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
