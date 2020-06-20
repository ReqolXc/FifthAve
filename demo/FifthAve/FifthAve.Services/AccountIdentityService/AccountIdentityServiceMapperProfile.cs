using AutoMapper;
using FifthAve.Services.AccountIdentityService.DomainModels.Account;
using FifthAve.Services.AccountIdentityService.DomainModels.AccountIdentity;
using FifthAve.Services.AccountService.Handlers.CreateAccount;

namespace FifthAve.Services.AccountIdentityService
{
    public class AccountIdentityServiceMapperProfile : Profile
    {
        public AccountIdentityServiceMapperProfile()
        {
            CreateMap<CreateAccountRequest, Account>();
            CreateMap<CreateAccountRequest, AccountIdentity>();
        }        
    }
}
