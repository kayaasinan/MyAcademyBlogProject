using Microsoft.Extensions.Configuration;

namespace Blogy.Business.Services.GoogleServices
{
    public class RecaptchaService(IConfiguration _configuration, HttpClient _httpClient) : IRecaptchaService
    {
        public async Task<bool> VerifyAsync(string token)
        {
            var secret = _configuration["ReCaptcha:SecretKey"];
            var url = _configuration["ReCaptcha:VerifyUrl"];

            var response = await _httpClient.PostAsync(
                $"{url}?secret={secret}&response={token}", null);

            var json = await response.Content.ReadAsStringAsync();
            dynamic result = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

            if (result.success != true)
                return false;

            if (result.action != "login")
                return false;

            double score = result.score;
            if (score < 0.5) 
                return false;

            return true;
        }
    }
}
