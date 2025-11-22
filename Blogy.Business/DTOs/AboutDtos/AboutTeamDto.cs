using Blogy.Business.DTOs.UserDTOs;

namespace Blogy.Business.DTOs.AboutDtos
{
    public class AboutTeamDto
    {
        public ResultAboutDto About { get; set; }
        public List<ResultUserDto> Team { get; set; }
    }
}
