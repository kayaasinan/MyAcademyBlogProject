using Blogy.Entity.Entities.Common;

namespace Blogy.Entity.Entities
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }
        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
        public int UserId { get; set; }
        public virtual AppUser User { get; set; }
        public CommentStatus Status { get; set; } = CommentStatus.Accepted;
    }
    public enum CommentStatus
    {
        Accepted = 0,     
        Review = 1,     
        Rejected = 2,   
        AutoBlocked = 3   
    }
}
