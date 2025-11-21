using Blogy.DataAccess.Repositories.GenericRepositories;
using Blogy.Entity.Entities;

namespace Blogy.DataAccess.Repositories.CommentRepositories
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
        Task<List<Comment>> GetCommentsByAccepted();
        Task<List<Comment>> GetCommentsForWriterAsync(int writerId);
        Task<List<Comment>> GetCommentsByUserAsync(int userId);
    }
}
