using DinnerInvite.Application.Common.Interfaces.Authentication;
using DinnerInvite.Application.Common.Interfaces.Persistence;
using DinnerInvite.Application.Common.Interfaces.Services;
using DinnerInvite.Infrastructure.Authentication;
using DinnerInvite.Infrastructure.Persistence;
using DinnerInvite.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace DinnerInvite.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection service,ConfigurationManager configurationManager){
            service.Configure<JwtSettings>(configurationManager.GetSection(JwtSettings.sectionName));
            service.AddSingleton<IjwtTokenGenearator,JwtTokenGenerator>();
            service.AddSingleton<IDateTimeProvider,DateTimeProvider>();
            service.AddScoped<IUserRepository,UserRepository>();
            service.AddScoped<IBreakfastRepository,BreakFastRepository>();
            return service;
        }
    }
}