using Blogy.Entity.Entities.Common;

namespace Blogy.Entity.Entities
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; }
        public string? TagColor { get; set; }

        public virtual IList<BlogTag> BlogTags { get; set; }

    }
}
