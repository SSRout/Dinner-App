using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace DinnerInvite.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection service){
            service.AddMediatR(typeof(DependencyInjection).Assembly);
            return service;
        }
    }
}