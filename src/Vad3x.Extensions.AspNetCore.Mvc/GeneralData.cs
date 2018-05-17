using Newtonsoft.Json;

namespace Microsoft.AspNetCore.Mvc
{
    public class GeneralData
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ErrorCode { get; set; }
    }
}
