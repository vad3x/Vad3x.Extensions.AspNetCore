using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.AspNetCore.Mvc.Recaptcha
{
    public class RecaptchaResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("error-codes")]
        public List<string> ErrorCodes { get; set; }
    }
}
