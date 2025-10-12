using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.UI_Layout
{
    public class _UILayoutScriptComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
