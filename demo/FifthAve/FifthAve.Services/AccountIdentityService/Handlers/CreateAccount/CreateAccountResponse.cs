using FifthAve.Services.AccountIdentityService.Handlers.JwtToken;

namespace FifthAve.Services.AccountIdentityService.Handlers.CreateAccount
{
    public class CreateAccountResponse : JwtTokenResponse
    {
        public CreateAccountResponse(string token) : base(token)
        { }
    }
}
