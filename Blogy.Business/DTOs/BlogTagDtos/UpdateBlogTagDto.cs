using Blogy.Business.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.DTOs.BlogTagDtos
{
    public class UpdateBlogTagDto : BaseDto
    {
        public int BlogId { get; set; }
        public int TagId { get; set; }
    }
}
