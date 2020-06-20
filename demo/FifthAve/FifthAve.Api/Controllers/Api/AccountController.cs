using System.Threading;
using System.Threading.Tasks;
using FifthAve.Api.Controllers.Api.Base;
using FifthAve.Services.AccountIdentityService.Handlers.CreateAccount;
using FifthAve.Services.AccountIdentityService.Handlers.JwtToken;
using FifthAve.Services.AccountService.Handlers.CreateAccount;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FifthAve.Api.Controllers.Api
{
    [Route("account")]
    public class AccountController : BaseController
    {
        public AccountController(IMediator mediator) : base(mediator)
        { }

        [AllowAnonymous]
        [HttpPost("create")]
        public Task<CreateAccountResponse> CreateAccount([FromBody] CreateAccountRequest request, CancellationToken cancellationToken) 
            => Send(request, cancellationToken);

        [AllowAnonymous]
        [HttpPost("token")]
        public Task<JwtTokenResponse> GetToken([FromBody] JwtTokenRequest request, CancellationToken cancellationToken)
            => Send(request, cancellationToken);

        [HttpPost("auth-test")]
        public Task<string> TestMethodWithAuthorization([FromBody] string request, CancellationToken cancellationToken)
            => Task.FromResult(request);
    }
}