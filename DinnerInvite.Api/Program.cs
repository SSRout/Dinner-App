using DinnerInvite.Application;
using DinnerInvite.Infrastructure;
using DinnerInvite.Api;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddPresentation()
                    .AddApplication()
                    .AddInfrastructure(builder.Configuration);

}

var app=builder.Build();
{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
