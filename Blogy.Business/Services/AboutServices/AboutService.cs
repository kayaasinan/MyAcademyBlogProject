using AutoMapper;
using Blogy.Business.DTOs.AboutDtos;
using Blogy.DataAccess.Repositories.AboutRepositories;
using Blogy.Entity.Entities;

namespace Blogy.Business.Services.AboutServices
{
    public class AboutService(IAboutRepository _aboutRepository, IMapper _mapper) : IAboutService
    {
        public async Task CreateAsync(CreateAboutDto dto)
        {
            var about = _mapper.Map<About>(dto);
            await _aboutRepository.CreateAsync(about);
        }

        public async Task DeleteAsync(int id)
        {
            await _aboutRepository.DeleteAsync(id);
        }

        public async Task<List<ResultAboutDto>> GetAllAsync()
        {
            var abouts = await _aboutRepository.GetAllAsync();
            return _mapper.Map<List<ResultAboutDto>>(abouts);
        }

        public async Task<UpdateAboutDto> GetByIdAsync(int id)
        {
            var about = await _aboutRepository.GetByIdAsync(id);
            return _mapper.Map<UpdateAboutDto>(about);
        }

        public Task<ResultAboutDto> GetSingleByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UpdateAboutDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
