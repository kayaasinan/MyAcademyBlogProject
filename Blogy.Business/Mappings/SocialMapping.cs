using AutoMapper;
using Blogy.Business.DTOs.SocialDtos;
using Blogy.Entity.Entities;

namespace Blogy.Business.Mappings
{
    public class SocialMapping : Profile
    {
        public SocialMapping()
        {
            CreateMap<Social,ResultSocialDto>().ReverseMap();
            CreateMap<Social,CreateSocialDto>().ReverseMap();
            CreateMap<Social,UpdateSocialDto>().ReverseMap();
        }
    }
}
