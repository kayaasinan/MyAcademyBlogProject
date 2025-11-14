using Blogy.Business.DTOs.BlogDtos;
using Blogy.Business.DTOs.Common;
using Blogy.Business.DTOs.TagDtos;

namespace Blogy.Business.DTOs.BlogTagDtos
{
    public class ResultBlogTagDto : BaseDto
    {
        public int BlogId { get; set; }
        public int TagId { get; set; }
        public ResultBlogDto Blog { get; set; }
        public ResultTagDto Tag { get; set; }
    }
}
