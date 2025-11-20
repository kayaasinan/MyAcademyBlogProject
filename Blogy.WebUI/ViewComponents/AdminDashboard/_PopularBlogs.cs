using Blogy.Business.Services.BlogServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blogy.WebUI.ViewComponents.AdminDashboard
{
    public class _PopularBlogs(IBlogService _blogService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var blogs = await _blogService.GetLast4BlogsAsync();
            return View(blogs);
        }
    }
}
