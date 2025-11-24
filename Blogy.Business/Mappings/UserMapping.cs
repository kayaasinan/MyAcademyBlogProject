using AutoMapper;
using Blogy.Business.DTOs.AboutDtos;
using Blogy.Business.DTOs.UserDTOs;
using Blogy.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.Mappings
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<AppUser, ResultUserDto>().ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName));
            CreateMap<AppUser, EditProfileDto>().ReverseMap();
            CreateMap<ResultAboutDto, ResultUserDto>().ReverseMap();
        }
    }
}
