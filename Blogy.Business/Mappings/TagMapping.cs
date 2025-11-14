using AutoMapper;
using Blogy.Business.DTOs.TagDtos;
using Blogy.Entity.Entities;

namespace Blogy.Business.Mappings
{
    public class TagMapping : Profile
    {
        public TagMapping()
        {
            CreateMap<Tag, ResultTagDto>().ReverseMap();
            CreateMap<Tag, UpdateTagDto>().ReverseMap();
            CreateMap<Tag, CreateTagDto>().ReverseMap();
        }
    }
}
