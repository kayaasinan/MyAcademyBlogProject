using Blogy.Entity.Entities;

namespace Blogy.Business.DTOs.CommentDtos
{
    public class CreateCommentDto
    {
        public string? Content { get; set; }
        public int BlogId { get; set; }
        public int UserId { get; set; }
        public CommentStatus Status { get; set; }
    }
}
