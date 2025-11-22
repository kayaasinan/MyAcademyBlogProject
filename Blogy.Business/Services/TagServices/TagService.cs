using AutoMapper;
using Blogy.Business.DTOs.BlogDtos;
using Blogy.Business.DTOs.TagDtos;
using Blogy.DataAccess.Repositories.TagRepositories;
using Blogy.Entity.Entities;

namespace Blogy.Business.Services.TagServices
{
    public class TagService(ITagRepository _tagRepository, IMapper _mapper) : ITagService
    {

        public Task CreateAsync(CreateTagDto dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultTagDto>> GetAllAsync()
        {
            var tags = await _tagRepository.GetAllAsync();
            return _mapper.Map<List<ResultTagDto>>(tags);
        }

        public async Task<UpdateTagDto> GetByIdAsync(int id)
        {
            var tag = await _tagRepository.GetByIdAsync(id);
            return _mapper.Map<UpdateTagDto>(tag);
        }

        public async Task<ResultTagDto> GetSingleByIdAsync(int id)
        {
            var tag = await _tagRepository.GetByIdAsync(id);
            return _mapper.Map<ResultTagDto>(tag);
        }

        public async Task UpdateAsync(UpdateTagDto dto)
        {
            var tag = _mapper.Map<Tag>(dto);
            await _tagRepository.UpdateAsync(tag);
        }
    }
}
