using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace FifthAve.Services.AccountIdentityService.Handlers.JwtToken
{
    public class JwtTokenHandler :
        IRequestHandler<JwtTokenRequest, JwtTokenResponse>
    {
        private readonly Services.AccountIdentityService.AccountIdentityService _accountIdentityService;
        public JwtTokenHandler(Services.AccountIdentityService.AccountIdentityService accountIdentityService)
        {
            _accountIdentityService = accountIdentityService;
        }

        public Task<JwtTokenResponse> Handle(JwtTokenRequest request, CancellationToken cancellationToken)
            => _accountIdentityService.GetJwtToken(request, cancellationToken);
    }
}
