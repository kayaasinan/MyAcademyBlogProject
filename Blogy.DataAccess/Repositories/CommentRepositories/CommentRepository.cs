using Blogy.DataAccess.Context;
using Blogy.DataAccess.Repositories.GenericRepositories;
using Blogy.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blogy.DataAccess.Repositories.CommentRepositories
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Comment>> GetCommentsByAccepted()
        {
            return await _table.Where(x => x.Status == CommentStatus.Accepted || x.Status==CommentStatus.Review).ToListAsync();
        }

        public async Task<List<Comment>> GetCommentsByUserAsync(int userId)
        {
            return await _table.Include(x=>x.Blog).Include(x=>x.User).Where(x=>x.UserId == userId).OrderByDescending(x=>x.CreatedDate).ToListAsync();
        }

        public async Task<List<Comment>> GetCommentsForWriterAsync(int writerId)
        {
            return await _table.Where(x => x.Blog.WriterId == writerId && x.Status == CommentStatus.Accepted).OrderByDescending(x => x.CreatedDate).ToListAsync();
        }
    }
}
