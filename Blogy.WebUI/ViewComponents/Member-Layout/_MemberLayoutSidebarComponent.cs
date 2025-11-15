using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.Member_Layout
{
    public class _MemberLayoutSidebarComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
