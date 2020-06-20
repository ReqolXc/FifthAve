using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SecurityKey = FifthAve.Utils.Cryptography.SecurityKey;

namespace FifthAve.Api.StartUps.Authorization
{
    public static class AuthenticationModule
    {
        public static IServiceCollection AddCustomAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(x =>
                {
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = "FifthAve",

                        ValidateAudience = true,
                        ValidAudience = "FifthAve.fe",

                        ValidateLifetime = true,

                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKey.SymmetricSecurityKey
                    };
                });

            return services;
        }
    }
}
