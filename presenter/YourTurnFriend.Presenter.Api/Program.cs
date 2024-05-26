using core.YourTurnFriend.Application;
using YourTurnFriend.Infra.Data;
using YourTurnFriend.Infra.ExternalServices;
using YourTurnFriend.Presenter.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddEndpointsApiExplorer()
        .AddSwaggerGen()
        .AddControllers();

    var enviroment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
    builder.Services
        .AddInfraData()
        .AddOutBoxMessgeInterceptor()
        .AddOutBoxMessageJob()
        .AddDataBase(builder.Configuration, enviroment)
        .AddApplicationLayer()
        .AddExternalService();
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseMiddleware<ResponseMiddleware>();
    app.UseHttpsRedirection();
    app.UseRouting();
    app.UseEndpoints(endppoint => endppoint.MapControllers());
    app.Run();
}

