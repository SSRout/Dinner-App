using DinnerInvite.Application;
using DinnerInvite.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplication().AddInfrastructure(builder.Configuration);
    builder.Services.AddControllers();
}

var app=builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
