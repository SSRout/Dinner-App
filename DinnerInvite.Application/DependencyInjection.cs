using Microsoft.Extensions.DependencyInjection;
using DinnerInvite.Application.Services.Authentications;
namespace DinnerInvite.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection service){
            service.AddScoped<IAuthenticationService,AuthenticationService>();
            return service;
        }
    }
}