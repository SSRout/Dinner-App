using DinnerInvite.Api.Common.Errors;
using DinnerInvite.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace DinnerInvite.Api
{
    public static class DependencyInjection
    {
      public static IServiceCollection AddPresentation(this IServiceCollection service){
            service.AddControllers();
            service.AddSingleton<ProblemDetailsFactory,DinnerAppProblemDetailsFactory>();
            service.AddMappings();
            return service;
       }
    }
}