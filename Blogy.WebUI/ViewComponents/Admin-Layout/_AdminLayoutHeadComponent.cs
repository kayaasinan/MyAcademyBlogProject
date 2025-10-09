using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.Admin_Layout
{
    public class _AdminLayoutHeadComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
