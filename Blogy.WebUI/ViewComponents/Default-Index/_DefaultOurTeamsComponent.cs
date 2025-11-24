using Blogy.Business.Services.BlogServices;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.Default_Index
{
    public class _DefaultOurTeamsComponent(IBlogService _blogService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var blog = await _blogService.GetSingleByIdAsync(id);
            var writer = blog.Writer;
            return View(writer);
        }
    }
}
