using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.UI_Layout
{
    public class _UILayoutNavbarComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
