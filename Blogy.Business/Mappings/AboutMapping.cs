using AutoMapper;
using Blogy.Business.DTOs.AboutDtos;
using Blogy.Entity.Entities;

namespace Blogy.Business.Mappings
{
    public class AboutMapping : Profile
    {
        public AboutMapping()
        {
            CreateMap<About,ResultAboutDto>().ReverseMap();
            CreateMap<About,CreateAboutDto>().ReverseMap();
            CreateMap<About,UpdateAboutDto>().ReverseMap();
        }
    }
}
