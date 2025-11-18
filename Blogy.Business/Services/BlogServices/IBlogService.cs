using Blogy.Business.DTOs.BlogDtos;
using Blogy.Business.DTOs.ChartDtos;

namespace Blogy.Business.Services.BlogServices
{
    public interface IBlogService : IGenericService<ResultBlogDto, UpdateBlogDto, CreateBlogDto>
    {
        Task<List<ResultBlogDto>> GetBlogsWithCategoriesAsync();
        Task<List<ResultBlogDto>> GetBlogsByCategoryIdAsync(int categoryId);
        Task<List<ResultBlogDto>> GetLast3BlogsAsync();
        Task<List<ResultBlogDto>> GetLast5BlogsAsync();
        Task<string> TGetLastWriterNameAsync();
        Task<List<CategoryChartDto>> TGetCategoryCountsAsync();
        Task<List<StatusChartDto>> TGetStatusCountsAsync();
    }
}
