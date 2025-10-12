using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.UI_Layout
{
    public class _UILayoutHeadComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
