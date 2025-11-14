using Blogy.Business.Services.BlogServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blogy.WebUI.ViewComponents.Default_Index
{
    public class _DefaultHomePageBlogs(IBlogService _blogService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var getLast5Blogs=await _blogService.GetLast5BlogsAsync();
            return View(getLast5Blogs);
        }
    }
}
