using Blogy.Business.DTOs.Common;

namespace Blogy.Business.DTOs.ContactUsDtos
{
    public class UpdateContactUsDto : BaseDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
