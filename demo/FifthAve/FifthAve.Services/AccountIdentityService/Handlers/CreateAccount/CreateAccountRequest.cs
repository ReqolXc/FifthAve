using System.ComponentModel;
using FifthAve.Services.AccountIdentityService.Handlers.CreateAccount;
using MediatR;
using Newtonsoft.Json;

namespace FifthAve.Services.AccountService.Handlers.CreateAccount
{
    public class CreateAccountRequest : IRequest<CreateAccountResponse>
    {
        [JsonProperty("firstName")]
        public string? FirstName { get; set; }

        [JsonProperty("lastName")]
        public string? LastName { get; set; }

        [JsonProperty("middleName")]
        public string? MiddleName { get; set; }

        [JsonProperty("username")]
        public string? Username { get; set; }

        [JsonProperty("password")]
        public string? Password { get; set; }

        [DefaultValue("email@email.ea")]
        [JsonProperty("email")]
        public string? Email { get; set; }

        [JsonProperty("phone")]
        public string? PhoneNumber { get; set; }
    }
}
