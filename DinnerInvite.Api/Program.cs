using DinnerInvite.Api.Common.Errors;
using DinnerInvite.Api.Filters;
using DinnerInvite.Api.Middleware;
using DinnerInvite.Application;
using DinnerInvite.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplication().AddInfrastructure(builder.Configuration);
   // builder.Services.AddControllers(options=>options.Filters.Add<ErrorHandlingFilterAttribute>());//2.Using Error Filter
   builder.Services.AddControllers();
   builder.Services.AddSingleton<ProblemDetailsFactory,DinnerAppProblemDetailsFactory>();//3.Using Problem Details Factory
}

var app=builder.Build();
{
    //app.UseMiddleware<ErrorHandlingMiddleWare>();//1.using Error MiddleWare
    //using Global Error Exception Handler
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
