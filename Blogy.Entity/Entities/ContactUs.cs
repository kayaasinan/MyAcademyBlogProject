using Blogy.Entity.Entities.Common;

namespace Blogy.Entity.Entities
{
    public class ContactUs : BaseEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
