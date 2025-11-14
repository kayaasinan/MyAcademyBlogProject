using AutoMapper;
using Blogy.Business.DTOs.ContactUsDtos;
using Blogy.Entity.Entities;

namespace Blogy.Business.Mappings
{
    public class ContactUsMapping : Profile
    {
        public ContactUsMapping()
        {
            CreateMap<ContactUs,ResultContactUsDto>().ReverseMap();
            CreateMap<ContactUs,UpdateContactUsDto>().ReverseMap();
            CreateMap<ContactUs,CreateContactUsDto>().ReverseMap();
        }
    }
}
