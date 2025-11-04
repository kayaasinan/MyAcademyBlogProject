using AutoMapper;
using Blogy.Business.DTOs.BlogDtos;
using Blogy.Business.DTOs.CommentDtos;
using Blogy.DataAccess.Repositories.CommentRepositories;
using Blogy.Entity.Entities;
using FluentValidation;

namespace Blogy.Business.Services.CommentServices
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<Comment> _validator;

        public CommentService(ICommentRepository commentRepository, IMapper mapper, IValidator<Comment> validator)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task CreateAsync(CreateCommentDto dto)
        {
            var comment = _mapper.Map<Comment>(dto);
            var result = await _validator.ValidateAsync(comment);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            await _commentRepository.CreateAsync(comment);
        }

        public async Task DeleteAsync(int id)
        {
            await _commentRepository.DeleteAsync(id);
        }

        public async Task<List<ResultCommentDto>> GetAllAsync()
        {
            var comments = await _commentRepository.GetAllAsync();
            return _mapper.Map<List<ResultCommentDto>>(comments);
        }

        public async Task<UpdateCommentDto> GetByIdAsync(int id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);
            return _mapper.Map<UpdateCommentDto>(comment);
        }

        public async Task UpdateAsync(UpdateCommentDto dto)
        {
            var comment = _mapper.Map<Comment>(dto);
            var result = await _validator.ValidateAsync(comment);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            await _commentRepository.UpdateAsync(comment);
        }
    }
}
