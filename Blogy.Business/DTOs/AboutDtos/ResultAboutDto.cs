using Blogy.Business.DTOs.Common;

namespace Blogy.Business.DTOs.AboutDtos
{
    public class ResultAboutDto : BaseDto
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public string ImageUrl1 { get; set; }
        public string ImageUrl2 { get; set; }
    }
}
