using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Mvc.Recaptcha
{
    public interface ICaptchaService
    {
        Task<bool> IsValidAsync(string captcha, string remoteIp);
    }
}
