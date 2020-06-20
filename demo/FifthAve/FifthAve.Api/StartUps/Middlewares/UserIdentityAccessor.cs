using System;
using System.Security.Claims;
using System.Threading.Tasks;
using FifthAve.Api.StartUps.Authorization;
using FifthAve.Core.Constants;
using Microsoft.AspNetCore.Http;
using MongoDB.Bson;

namespace FifthAve.Api.StartUps.Middlewares
{
    public class UserIdentityAccessor
    {
        private readonly RequestDelegate _next;

        public UserIdentityAccessor(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IUserIdentity userIdentity)
        {
            var user = (ClaimsIdentity)context.User.Identity;

            if (user.IsAuthenticated)
            {
                var id = user.FindFirst(ClaimNames.Id).Value;
                userIdentity.Id = ObjectId.Parse(id);
                userIdentity.IsAuthenticated = true;
            }
            else
            {
                userIdentity.Id = ObjectId.Empty;
                userIdentity.IsAuthenticated = false;
            }

            await _next(context);
        }
    }
}
