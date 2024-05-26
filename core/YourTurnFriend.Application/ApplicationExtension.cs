using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using YourTurnFriend.Application.Wrappers.DomainWrappers;
using YourTurnFriend.Domain.DomainEvents;

namespace core.YourTurnFriend.Application;

public static class ApplicationExtension
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddScoped<IPublisherDomainEvent, PublisherDomainEvent>();

        return services;
    }
}