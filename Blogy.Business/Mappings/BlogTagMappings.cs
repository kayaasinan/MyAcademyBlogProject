using AutoMapper;
using Blogy.Business.DTOs.BlogTagDtos;
using Blogy.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.Mappings
{
    public class BlogTagMappings:Profile
    {
        public BlogTagMappings()
        {
            CreateMap<BlogTag,ResultBlogTagDto>().ReverseMap();
            CreateMap<BlogTag,UpdateBlogTagDto>().ReverseMap();
            CreateMap<BlogTag,CreateBlogTagDto>().ReverseMap();
        }
    }
}
