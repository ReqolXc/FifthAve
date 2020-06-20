using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FifthAve.Core.Constants;
using FifthAve.Core.Database;
using FifthAve.Services.AccountIdentityService.DomainModels.Account;
using FifthAve.Services.AccountIdentityService.DomainModels.AccountIdentity;
using FifthAve.Services.AccountIdentityService.Handlers.CreateAccount;
using FifthAve.Services.AccountIdentityService.Handlers.JwtToken;
using FifthAve.Services.AccountService.Handlers.CreateAccount;
using FifthAve.Utils.Cryptography;
using Microsoft.IdentityModel.Tokens;
using SecurityKey = FifthAve.Utils.Cryptography.SecurityKey;

namespace FifthAve.Services.AccountIdentityService
{
    public class AccountIdentityService
    {
        private readonly IBaseRepository<AccountIdentity> _accountIdentityRepository;
        private readonly IDatabaseSessionProvider _databaseSessionProvider;
        private readonly IMapper _mapper;

        public AccountIdentityService(IBaseRepository<AccountIdentity> accountIdentityRepository,
            IDatabaseSessionProvider databaseSessionProvider,
            IMapper mapper)
        {
            _accountIdentityRepository = accountIdentityRepository;
            _mapper = mapper;
            _databaseSessionProvider = databaseSessionProvider;
        }

        public async Task<CreateAccountResponse> CreateAccount(CreateAccountRequest request, CancellationToken cancellationToken)
        {
            var account = _mapper.Map<CreateAccountRequest, Account>(request);
            var accountIdentity = _mapper.Map<CreateAccountRequest, AccountIdentity>(request);

            accountIdentity.HashedPassword = PasswordHasher.HashPassword(request.Password!);
            
            using (var session = await _databaseSessionProvider.StartSession(cancellationToken))
            {
                var accountRepository = session.GetRepository<Account>();
                var accountIdentityRepository = session.GetRepository<AccountIdentity>();

                session.StartTransaction();

                await accountRepository.InsertAsync(account, cancellationToken);
                
                accountIdentity.Id = account.Id; //account and identity should has same id
                await accountIdentityRepository.InsertAsync(accountIdentity, cancellationToken);

                await session.CommitTransactionAsync(cancellationToken);
            }

            var token = await GetJwtToken(request.Username!, request.Password!, cancellationToken);
            return new CreateAccountResponse(token);
        }

        public async Task<JwtTokenResponse> GetJwtToken(JwtTokenRequest request, CancellationToken cancellationToken)
        {
            var token = await GetJwtToken(request.Username!, request.Password!, cancellationToken);
            return new JwtTokenResponse(token);
        }

        private async Task<string> GetJwtToken(string username, string password, CancellationToken cancellationToken)
        {
            var accountIdentity = await _accountIdentityRepository.FindOneAsync(x => x.Username == username, cancellationToken);
            
            if(accountIdentity == null)
                throw new NotImplementedException();

            if (!PasswordHasher.Verify(password, accountIdentity.HashedPassword))
                throw new NotImplementedException();

            var claims = new List<Claim>
            {
                new Claim(ClaimNames.Id, accountIdentity.Id.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, "Bearer");

            if (claimsIdentity == null)
                throw new NotImplementedException();
            

            var now = DateTime.UtcNow;
            var lifetimeInDays = TimeSpan.FromDays(30);

            var token = new JwtSecurityToken(
                issuer: "FifthAve",
                audience: "FifthAve.fe",
                notBefore: now,
                claims: claimsIdentity.Claims,
                expires: now.Add(lifetimeInDays),
                signingCredentials: new SigningCredentials(SecurityKey.SymmetricSecurityKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}