using AutoMapper;
using Blogy.Business.DTOs.ContactUsDtos;
using Blogy.DataAccess.Repositories.ContactUsRepositories;
using Blogy.Entity.Entities;
using FluentValidation;

namespace Blogy.Business.Services.ContactUsServices
{
    public class ContactUsService(IContactUsRepository _contactUsRepository,IMapper _mapper, IValidator<ContactUs> _validator) : IContactUsService
    {
        public async Task CreateAsync(CreateContactUsDto dto)
        {
            var message = _mapper.Map<ContactUs>(dto);
            var result = await _validator.ValidateAsync(message);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            await _contactUsRepository.CreateAsync(message);
        }

        public async Task DeleteAsync(int id)
        {
            await _contactUsRepository.DeleteAsync(id);
        }

        public Task<List<ResultContactUsDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UpdateContactUsDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResultContactUsDto> GetSingleByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UpdateContactUsDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
