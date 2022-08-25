using System.Text;
using DinnerInvite.Application.Common.Interfaces.Authentication;
using DinnerInvite.Application.Common.Interfaces.Persistence;
using DinnerInvite.Application.Common.Interfaces.Services;
using DinnerInvite.Infrastructure.Authentication;
using DinnerInvite.Infrastructure.Persistence;
using DinnerInvite.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DinnerInvite.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection service,ConfigurationManager configurationManager)
        {
            service.AddAuth(configurationManager);
            service.AddSingleton<IDateTimeProvider,DateTimeProvider>();
            service.AddScoped<IUserRepository,UserRepository>();
            service.AddScoped<IBreakfastRepository,BreakFastRepository>();
            return service;
        }
         public static IServiceCollection AddAuth(this IServiceCollection service,ConfigurationManager configurationManager)
         {
            var jwtSettings=new JwtSettings();
            configurationManager.Bind(JwtSettings.sectionName,jwtSettings);

             service.AddSingleton(Options.Create(jwtSettings));
             service.AddSingleton<IjwtTokenGenearator,JwtTokenGenerator>();

             service.AddAuthentication(defaultScheme:JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(optins => new TokenValidationParameters{
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime=true,
                ValidIssuer=jwtSettings.issuer,
                ValidAudience=jwtSettings.auddiance,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.secret))
             });
             return service;
         }
    }
}