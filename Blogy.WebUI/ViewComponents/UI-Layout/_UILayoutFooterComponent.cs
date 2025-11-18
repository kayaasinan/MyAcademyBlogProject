using Blogy.Business.Services.BlogServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blogy.WebUI.ViewComponents.UI_Layout
{
    public class _UILayoutFooterComponent(IBlogService _blogService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values= await _blogService.GetLast3BlogsAsync();
            return View(values);
        }
    }
}
