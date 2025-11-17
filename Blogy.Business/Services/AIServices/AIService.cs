using Blogy.Business.DTOs.AIDtos;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace Blogy.Business.Services.AIServices
{
    public class AIService(IConfiguration _configuration) : IAIService
    {
        public async Task<AIResponseDto> GenerateAboutTextAsync()
        {
            var apiKey = _configuration["OpenAI:ApiKey"];
            var url = _configuration["OpenAI:BaseUrl"];

            var request = new AIRequestDto
            {
                messages = new List<AIMessageDto>
                {
                     new AIMessageDto
                     {
                         content = "Blogy hakkında yaklaşık 1000 karakterlik modern, doğal, akıcı bir tanıtım yazısı üret."
                     }
                }
            };

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", apiKey);

            var jsonBody = JsonConvert.SerializeObject(request);

            var response = await client.PostAsync(
                url,
                new StringContent(jsonBody, Encoding.UTF8, "application/json")
            );

            var json = await response.Content.ReadAsStringAsync();

            dynamic result = JsonConvert.DeserializeObject(json);

            string text = result.choices[0].message.content;

            return new AIResponseDto { content = text };

        }

        public async Task<AIResponseDto> GenerateReplyAsync(string userMessage)
        {
            var apiKey = _configuration["OpenAI:ApiKey"];
            var url = _configuration["OpenAI:BaseUrl"];

            var request = new AIRequestDto
            {
                messages = new List<AIMessageDto>
            {
                new AIMessageDto
                {
                    content =
                        "Kullanıcı mesajı: " + userMessage +
                        "\n\nBu mesaj hangi dilde yazılmışsa, o dilde doğal bir yanıt üret. Sadece yanıtı ver."
                }
            }
            };

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", apiKey);

            var jsonBody = JsonConvert.SerializeObject(request);

            var response = await client.PostAsync(url, new StringContent(jsonBody, Encoding.UTF8, "application/json"));

            var json = await response.Content.ReadAsStringAsync();

            dynamic result = JsonConvert.DeserializeObject(json);

            string reply = result.choices[0].message.content;

            return new AIResponseDto
            {
                content = reply
            };
        }

        public async Task<double> GetToxicityScoreAsync(string text)
        {
            var apiKey = _configuration["OpenAI:ApiKey"];
            var url = _configuration["OpenAI:BaseUrl"];

            var body = new
            {
                model = "omni-moderation-latest",
                input = text
            };

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", apiKey);

            var response = await client.PostAsJsonAsync(url, body);
            var json = await response.Content.ReadAsStringAsync();

            dynamic result = JsonConvert.DeserializeObject(json);

            double score =
                result.results[0].category_scores.hate ??
                result.results[0].category_scores.harassment ??
                result.results[0].category_scores["hate/threatening"] ??
                0;

            return score;
        }
    }
}
