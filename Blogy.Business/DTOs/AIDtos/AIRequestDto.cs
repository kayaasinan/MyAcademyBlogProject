namespace Blogy.Business.DTOs.AIDtos
{
    public class AIRequestDto
    {
        public string model { get; set; } = "gpt-4o-mini";
        public List<AIMessageDto> messages { get; set; }
    }
}
