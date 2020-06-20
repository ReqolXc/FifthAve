using Newtonsoft.Json;

namespace FifthAve.Services.AccountIdentityService.Handlers.JwtToken
{
    public class JwtTokenResponse
    {
        public JwtTokenResponse(string token)
        {
            AccessToken = token;
        }

        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }
    }
}