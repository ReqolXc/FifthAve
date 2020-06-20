using System.Threading;
using System.Threading.Tasks;
using FifthAve.Services.AccountIdentityService.Handlers.CreateAccount;
using MediatR;

namespace FifthAve.Services.AccountService.Handlers.CreateAccount
{
    public class CreateAccountHandler : 
        IRequestHandler<CreateAccountRequest, CreateAccountResponse>
    {
        private readonly AccountIdentityService.AccountIdentityService _accountIdentityService;

        public CreateAccountHandler(AccountIdentityService.AccountIdentityService accountIdentityService)
        {
            _accountIdentityService = accountIdentityService;
        }

        public Task<CreateAccountResponse> Handle(CreateAccountRequest request, CancellationToken cancellationToken) 
            => _accountIdentityService.CreateAccount(request, cancellationToken);
    }
}
