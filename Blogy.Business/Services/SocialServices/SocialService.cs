using AutoMapper;
using Blogy.Business.DTOs.BlogDtos;
using Blogy.Business.DTOs.SocialDtos;
using Blogy.DataAccess.Repositories.SocialRepositories;
using Blogy.Entity.Entities;

namespace Blogy.Business.Services.SocialServices
{
    public class SocialService(ISocialRepository _socialRepository,IMapper _mapper) : ISocialService
    {
        public async Task CreateAsync(CreateSocialDto dto)
        {
            var social=_mapper.Map<Social>(dto);
            await _socialRepository.CreateAsync(social);
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultSocialDto>> GetAllAsync()
        {
            var socials=await _socialRepository.GetAllAsync();
            return _mapper.Map<List<ResultSocialDto>>(socials);
        }

        public async Task<UpdateSocialDto> GetByIdAsync(int id)
        {
            var social = await _socialRepository.GetByIdAsync(id);
            return _mapper.Map<UpdateSocialDto>(social);
        }

        public Task<ResultSocialDto> GetSingleByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(UpdateSocialDto dto)
        {
            var social = _mapper.Map<Social>(dto);
            await _socialRepository.UpdateAsync(social);
        }
    }
}
