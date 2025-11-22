using AutoMapper;
using Blogy.Business.DTOs.AboutDtos;
using Blogy.Business.DTOs.UserDTOs;
using Blogy.Entity.Entities;

namespace Blogy.Business.Mappings
{
    public class AboutMapping : Profile
    {
        public AboutMapping()
        {
            CreateMap<About,ResultAboutDto>().ReverseMap();
            CreateMap<ResultUserDto,ResultAboutDto>().ReverseMap();
            CreateMap<About,CreateAboutDto>().ReverseMap();
            CreateMap<About,UpdateAboutDto>().ReverseMap();

        }
    }
}
