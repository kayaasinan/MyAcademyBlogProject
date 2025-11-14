using Blogy.Business.Services.TagServices;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.BlogsByCategory
{
    public class _AllTagsComponent(ITagService _tagService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var tags = await _tagService.GetAllAsync();
            return View(tags);
        }
    }
}
