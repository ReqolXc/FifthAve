using MediatR;
using Newtonsoft.Json;

namespace FifthAve.Services.AccountIdentityService.Handlers.JwtToken
{
    public class JwtTokenRequest : IRequest<JwtTokenResponse>
    {
        [JsonProperty("username")]
        public string? Username { get; set; }

        [JsonProperty("password")]
        public string? Password { get; set; }
    }
}