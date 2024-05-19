using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace core.YourTurnFriend.Application;

public static class ApplicationExtension
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }
}