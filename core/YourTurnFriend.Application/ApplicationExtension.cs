using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using YourTurnFriend.Application.Wrappers.DomainWrappers;
using YourTurnFriend.Domain.DomainEvents;
using YourTurnFriend.Domain.DomainServices;
using YourTurnFriend.Domain.DomainServices.Implementations;
using YourTurnFriend.Domain.DomainServices.Interfaces;
using YourTurnFriend.Domain.SeedWorks;

namespace core.YourTurnFriend.Application;

public static class ApplicationExtension
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddScoped<IPublisherDomainEvent, PublisherDomainEvent>();


        return services;
    }

    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped<IAddRoleToUserService, AddRolesToUserService>();

        return services;
    }
}