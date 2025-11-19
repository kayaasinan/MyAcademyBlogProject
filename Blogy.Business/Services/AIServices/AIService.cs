using Blogy.Business.DTOs.AIDtos;
using Blogy.DataAccess.Repositories.BlogRepositories;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Blogy.Business.Services.AIServices
{
    public class AIService(IConfiguration _configuration, IBlogRepository _blogRepository) : IAIService
    {
  
        private async Task<dynamic> SendAsyncBase(string url, object body)
        {
            var apiKey = _configuration["OpenAI:ApiKey"];

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", apiKey);

            var json = JsonConvert.SerializeObject(body);

            var response = await client.PostAsync(url,new StringContent(json, Encoding.UTF8, "application/json"));

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject(content);
        }
        private async Task<dynamic> SendChatAsync(object body)
        {
            string url = _configuration["OpenAI:ChatUrl"];
            return await SendAsyncBase(url, body);
        }
        private async Task<dynamic> SendModerationAsync(object body)
        {
            string url = _configuration["OpenAI:ModerationUrl"];
            return await SendAsyncBase(url, body);
        }
        public async Task<AIResponseDto> GenerateAboutTextAsync()
        {
            var request = new AIRequestDto
            {
                messages = new List<AIMessageDto>
            {
                new AIMessageDto
                {
                    role = "user",
                    content = "Blogy blog sayfası hakkında 1000 karakterlik bir hakkımızda içerikli modern bir metin yaz."
                }
            }
            };

            dynamic result = await SendChatAsync(request);

            return new AIResponseDto
            {
                content = result.choices[0].message.content
            };
        }

        public async Task<AIResponseDto> GenerateReplyAsync(string userMessage)
        {
            var request = new AIRequestDto
            {
                messages = new List<AIMessageDto>
            {
                new AIMessageDto
                {
                    role = "user",
                    content = $"Kullanıcı mesajı: {userMessage}"
                }
            }
            };

            dynamic result = await SendChatAsync(request);

            return new AIResponseDto
            {
                content = result.choices[0].message.content
            };
        }

        public async Task<double> GetToxicityScoreAsync(string text)
        {
            var request = new
            {
                model = "omni-moderation-latest",
                input = text
            };

            dynamic result = await SendModerationAsync(request);

            var scores = result.results[0].category_scores;

            double hate = (double?)scores.hate ?? 0;
            double harassment = (double?)scores.harassment ?? 0;
            double violence = (double?)scores.violence ?? 0;
            double threat = (double?)scores.threat ?? 0;

            return new[] { hate, harassment, violence, threat }.Max();
        }

        public async Task<List<AISuggestedDto>> GetSuggestionsAsync(int blogId)
        {
            var current = await _blogRepository.GetByIdAsync(blogId);

            var blogs = await _blogRepository.GetAllAsync();

            var list = blogs
                .Where(x => x.Id != blogId && x.CategoryId == current.CategoryId)
                .OrderByDescending(x => x.CreatedDate)
                .Take(3)
                .Select(x => new AISuggestedDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    CoverImage = x.CoverImage,
                    Score = Random.Shared.Next(82, 98) 
                }) .ToList();

            return list;
        }
    }
}
