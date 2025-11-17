using Blogy.Entity.Entities.Common;

namespace Blogy.Entity.Entities
{
    public class About : BaseEntity
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public string ImageUrl1 { get; set; }
        public string ImageUrl2 { get; set; }
    }
}
