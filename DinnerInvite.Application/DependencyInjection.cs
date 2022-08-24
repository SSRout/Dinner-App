using Microsoft.Extensions.DependencyInjection;
using MediatR;
using DinnerInvite.Application.Authentication.Commands.Register;
using DinnerInvite.Application.Authentication.Common;
using DinnerInvite.Application.Common.Behaviors;
using ErrorOr;
using FluentValidation;
using System.Reflection;

namespace DinnerInvite.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection service){
            service.AddMediatR(typeof(DependencyInjection).Assembly);
            service.AddScoped(typeof(IPipelineBehavior<,>),typeof(ValidationBehavior<,>));
            service.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return service;
        }
    }
}