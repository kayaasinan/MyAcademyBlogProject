using Blogy.Business.Services.BlogServices;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.BlogsByCategory
{
    public class _BlogTagsByBlogId(IBlogService _blogService) : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync(int blogId)
        {
            var blog = await _blogService.GetSingleByIdAsync(blogId);

            return View(blog.BlogTags);
        }
    }
}
