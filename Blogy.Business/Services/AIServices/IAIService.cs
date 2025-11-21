using Blogy.Business.DTOs.AIDtos;

namespace Blogy.Business.Services.AIServices
{
    public interface IAIService
    {

        Task<AIResponseDto> GenerateAboutTextAsync();
        Task<AIResponseDto> GenerateReplyAsync(string userMessage);
        Task<double> GetToxicityScoreAsync(string text);
        Task<List<AISuggestedDto>> GetSuggestionsAsync(int blogId);
        Task<AIResponseDto> GenerateArticleAsync(AIArticleDto dto);
    }
}
