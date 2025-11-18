using Blogy.Business.DTOs.CommentDtos;
using Blogy.Entity.Entities;

namespace Blogy.Business.Services.CommentServices
{
    public interface ICommentService : IGenericService<ResultCommentDto, UpdateCommentDto, CreateCommentDto>
    {
        Task<List<ResultCommentDto>> GetCommentsByAccepted();
    }
}
