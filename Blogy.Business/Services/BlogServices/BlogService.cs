using AutoMapper;
using Blogy.Business.DTOs.BlogDtos;
using Blogy.Business.DTOs.ChartDtos;
using Blogy.DataAccess.Repositories.BlogRepositories;
using Blogy.Entity.Entities;

namespace Blogy.Business.Services.BlogServices
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public BlogService(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(CreateBlogDto dto)
        {
            var blog = _mapper.Map<Blog>(dto);
            await _blogRepository.CreateAsync(blog);
        }

        public async Task DeleteAsync(int id)
        {
            await _blogRepository.DeleteAsync(id);
        }

        public async Task<List<ResultBlogDto>> GetAllAsync()
        {
            var blogs = await _blogRepository.GetAllAsync();
            return _mapper.Map<List<ResultBlogDto>>(blogs);
        }

        public async Task<List<ResultBlogDto>> GetBlogsByCategoryIdAsync(int categoryId)
        {
            var blog = await _blogRepository.GetBlogsByCategoryIdAsync(categoryId);
            return _mapper.Map<List<ResultBlogDto>>(blog);
        }

        public async Task<List<ResultBlogDto>> GetBlogsWithCategoriesAsync()
        {
            var blog = await _blogRepository.GetBlogsWithCategoriesAsync();
            return _mapper.Map<List<ResultBlogDto>>(blog);
        }

        public async Task<UpdateBlogDto> GetByIdAsync(int id)
        {
            var blog = await _blogRepository.GetByIdAsync(id);
            return _mapper.Map<UpdateBlogDto>(blog);
        }

        public async Task<List<ResultBlogDto>> GetLast3BlogsAsync()
        {
            var blogs = await _blogRepository.GetLast3BlogsAsync();
            return _mapper.Map<List<ResultBlogDto>>(blogs);
        }

        public async Task<List<ResultBlogDto>> GetLast5BlogsAsync()
        {
            var blogs = await _blogRepository.GetLast5BlogsAsync();
            return _mapper.Map<List<ResultBlogDto>>(blogs);
        }

        public async Task<ResultBlogDto> GetSingleByIdAsync(int id)
        {
            var blog = await _blogRepository.GetByIdAsync(id);
            return _mapper.Map<ResultBlogDto>(blog);
        }

        public async Task<int> TGetTotalBlogCountAsync()
        {
            return await _blogRepository.GetTotalBlogCountAsync();
        }

        public async Task<List<ResultBlogDto>> TGetBlogsByWriterIdAsync(int writerId)
        {
            var blogs = await _blogRepository.GetBlogsByWriterIdAsync(writerId);
            return _mapper.Map<List<ResultBlogDto>>(blogs);
        }

        public async Task<List<CategoryChartDto>> TGetCategoryCountsAsync()
        {
            var blogs = await GetAllAsync();

            return blogs.GroupBy(x => x.Category.CategoryName).Select(g => new CategoryChartDto
            {
                CategoryName = g.Key,
                Count = g.Count()
            }).ToList();
        }

        public async Task<string> TGetLastWriterNameAsync()
        {
            return await _blogRepository.GetLastWriterNameAsync();
        }

        public async Task<List<StatusChartDto>> TGetStatusCountsAsync()
        {
            var blogs = await GetAllAsync();

            return blogs.GroupBy(x => x.Status).Select(x => new StatusChartDto
            {
                Status = x.Key switch
                {
                    BlogStatus.Pending => "Beklemede",
                    BlogStatus.Accepted => "Onaylandı",
                    BlogStatus.Rejected => "Reddedildi",
                    _ => "Bilinmiyor"
                },
                Count = x.Count()
            }).ToList();
        }

        public async Task UpdateAsync(UpdateBlogDto dto)
        {
            var blog = _mapper.Map<Blog>(dto);
            await _blogRepository.UpdateAsync(blog);
        }

        public async Task<ResultBlogDto> TGetMostCommentedBlogAsync()
        {
            var blog = await _blogRepository.GetMostCommentedBlogAsync();
            return _mapper.Map<ResultBlogDto>(blog);
        }

        public async Task<List<ResultBlogDto>> GetLast4BlogsAsync()
        {
            var blogs = await _blogRepository.GetLast4BlogsAsync();
            return _mapper.Map<List<ResultBlogDto>>(blogs);
        }

        public async Task ChangeBlogStatusAsync(int id, BlogStatus newStatus)
        {
            await _blogRepository.ChangeBlogStatusAsync(id, newStatus);
        }

        public async Task<List<ResultBlogDto>> TGetBlogsByAccepted()
        {
            var blogs=await _blogRepository.GetBlogsByAccepted();
            return _mapper.Map<List<ResultBlogDto>>(blogs);
        }
    }
}
