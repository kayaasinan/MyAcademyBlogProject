using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.HelperComponent
{
    public class _EmptyPageComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var emptyPageMessage = "Görüntülenecek yorum bulunamadı..!";
            return View("Default", emptyPageMessage);
        }
    }
}
