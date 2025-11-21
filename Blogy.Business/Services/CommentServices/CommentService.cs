using AutoMapper;
using Blogy.Business.DTOs.CommentDtos;
using Blogy.Business.Services.AIServices;
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
        private readonly IAIService _aIService;

        public CommentService(ICommentRepository commentRepository, IMapper mapper, IValidator<Comment> validator, IAIService aIService)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
            _validator = validator;
            _aIService = aIService;
        }

        public async Task CreateAsync(CreateCommentDto dto)
        {
         
            double toxicity = await _aIService.GetToxicityScoreAsync(dto.Content);

            if (toxicity < 0.10)
                dto.Status = CommentStatus.Accepted;
            else if (toxicity < 0.30)
                dto.Status = CommentStatus.Review;
            else if (toxicity < 0.60)
                dto.Status = CommentStatus.Rejected;
            else
                dto.Status = CommentStatus.AutoBlocked;

            if (dto.Status == CommentStatus.AutoBlocked)
                return;

            var comment = _mapper.Map<Comment>(dto);

            var result = await _validator.ValidateAsync(comment);

            if (!result.IsValid)
                throw new ValidationException(result.Errors);

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

        public async Task<List<ResultCommentDto>> GetCommentsByAccepted()
        {
            var comments=await _commentRepository.GetCommentsByAccepted();
            return _mapper.Map<List<ResultCommentDto>>(comments);
        }

        public async Task<List<ResultCommentDto>> TGetCommentsByUserAsync(int userId)
        {
            var comments = await _commentRepository.GetCommentsByUserAsync(userId);
            return _mapper.Map<List<ResultCommentDto>>(comments);
        }

        public async Task<ResultCommentDto> GetSingleByIdAsync(int id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);
            return _mapper.Map<ResultCommentDto>(comment);
        }

        public async Task<List<ResultCommentDto>> TGetCommentsForWriterAsync(int writerId)
        {
            var comments=await _commentRepository.GetCommentsForWriterAsync(writerId);
            return _mapper.Map<List<ResultCommentDto>>(comments);
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
