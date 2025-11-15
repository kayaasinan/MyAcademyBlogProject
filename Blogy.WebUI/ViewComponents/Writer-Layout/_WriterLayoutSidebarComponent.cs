using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.Writer_Layout
{
    public class _WriterLayoutSidebarComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
