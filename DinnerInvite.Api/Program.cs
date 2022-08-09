using DinnerInvite.Api.Filters;
using DinnerInvite.Api.Middleware;
using DinnerInvite.Application;
using DinnerInvite.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplication().AddInfrastructure(builder.Configuration);
   // builder.Services.AddControllers(options=>options.Filters.Add<ErrorHandlingFilterAttribute>());//Using Error Filter
   builder.Services.AddControllers();
}

var app=builder.Build();
{
    //app.UseMiddleware<ErrorHandlingMiddleWare>();//using Error MiddleWare
    //using Global Error Exception Handler
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
