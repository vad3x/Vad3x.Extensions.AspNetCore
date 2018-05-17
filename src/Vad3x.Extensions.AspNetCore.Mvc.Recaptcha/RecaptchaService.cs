using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Mvc.Recaptcha
{
    public class RecaptchaService : ICaptchaService
    {
        private readonly ILogger _logger;
        private readonly RecaptchaOptions _recaptchaOptions;

        private readonly string _endpointUri;

        public RecaptchaService(
            ILogger<RecaptchaService> logger,
            IOptions<RecaptchaOptions> recaptchaOptions)
        {
            _logger = logger;
            _recaptchaOptions = recaptchaOptions.Value;

            _endpointUri = _recaptchaOptions.EndpointUri + "?secret={0}&response={1}&remoteip={2}";
        }

        public async Task<bool> IsValidAsync(string captcha, string remoteIp)
        {
            string response;
            using (var httpClient = new HttpClient())
            {
                response = await httpClient.GetStringAsync(string.Format(_endpointUri, _recaptchaOptions.Secret, captcha, remoteIp));
            }

            var captchaResponse = JsonConvert.DeserializeObject<RecaptchaResponse>(response);
            if (!captchaResponse.Success)
            {
                if (captchaResponse.ErrorCodes == null || captchaResponse.ErrorCodes.Count <= 0)
                {
                    return false;
                }

                var error = captchaResponse.ErrorCodes[0].ToLower();
                switch (error)
                {
                    case "missing-input-secret":
                        _logger.LogWarning("IP: `{remoteIp}`: The secret parameter is missing.", remoteIp);
                        break;

                    case "invalid-input-secret":
                        _logger.LogWarning("IP: `{remoteIp}`: The secret parameter is invalid or malformed.", remoteIp);
                        break;

                    case "missing-input-response":
                        _logger.LogWarning("IP: `{remoteIp}`: The response parameter is missing.", remoteIp);
                        break;

                    case "invalid-input-response":
                        _logger.LogWarning("IP: `{remoteIp}`: The response parameter is invalid or malformed.", remoteIp);
                        break;

                    default:
                        _logger.LogWarning("IP: `{remoteIp}`: Error occured. Please try again", remoteIp);
                        break;
                }

                return false;
            }

            return true;
        }
    }
}
