using Blogy.Business.Services.AIServices;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.BlogsByCategory
{
    public class _AISuggestionViewComponent(IAIService _aIService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int blogId)
        {
            var result = await _aIService.GetSuggestionsAsync(blogId);
            return View(result);
        }
    }
}
