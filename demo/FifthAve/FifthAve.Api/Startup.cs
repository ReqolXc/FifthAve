using FifthAve.Api.StartUps.Authorization;
using FifthAve.Api.StartUps.Configuration;
using FifthAve.Api.StartUps.Mapping;
using FifthAve.Api.StartUps.Mediator;
using FifthAve.Api.StartUps.Middlewares;
using FifthAve.Api.StartUps.Serialization;
using FifthAve.Api.StartUps.Validation;
using FifthAve.Core;
using FifthAve.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FifthAve.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(x =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();

                x.Filters.Add(new AuthorizeFilter(policy));
            }).AddJsonSerialization();

            services.AddScoped<IUserIdentity, UserIdentity>();

            //modules
            services.AddCustomAuthentication();
            services.AddCustomAuthorization();
            services.AddConfiguration();
            services.AddApiModule();
            services.AddCoreModule();
            services.AddServices();

            services.AddMapper();
            services.AddFluentValidator();

            services.AddSwaggerGen();
            services.AddMediator();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader());
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(x => x.SwaggerEndpoint("/swagger/v1/swagger.json", "Fifth Ave api"));

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<UserIdentityAccessor>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
