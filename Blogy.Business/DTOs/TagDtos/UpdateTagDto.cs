using Blogy.Business.DTOs.Common;
using Blogy.Entity.Entities;

namespace Blogy.Business.DTOs.TagDtos
{
    public class UpdateTagDto : BaseDto
    {
        public string Name { get; set; }
        public string TagColor { get; set; }
    }
}
