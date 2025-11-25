namespace Blogy.Business.Services.GoogleServices
{
    public interface IRecaptchaService
    {
        Task<bool> VerifyAsync(string token);
    }
}
