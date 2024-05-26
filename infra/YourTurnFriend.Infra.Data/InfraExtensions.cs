using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YourTurnFriend.Domain.Contracts.Persistence;
using YourTurnFriend.Domain.Repositories;
using YourTurnFriend.Infra.Data.Context;
using YourTurnFriend.Infra.Data.Repositories;
using YourTurnFriend.Infra.Data.Transactions;

namespace YourTurnFriend.Infra.Data;

public static class InfraExtensions
{
    public static IServiceCollection AddInfraData(this IServiceCollection services)
    {
        services.AddScoped<IEventRepository, EventRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }

    public static IServiceCollection AddDataBase(this IServiceCollection services, IConfiguration configuration, string? enviroment)
    {
        var connection = configuration.GetConnectionString("DefaultConnection");

        if (enviroment == "Production")
        {
            connection = configuration.GetConnectionString("Production");
        }
        
        services.AddDbContext<ApplicationDbContext>((serviceProvider, options) => 
        {
            var outBoxMessageInterceptor = serviceProvider.GetService<ConvertDomainEventsToOutBoxMessagesInterceptor>();
            
            options.UseSqlite(connection);
            
            if (outBoxMessageInterceptor != null)
            {
                options.AddInterceptors(outBoxMessageInterceptor);
            }
        });

        return services;
    }

    public static IServiceCollection AddOutBoxMessgeInterceptor(this IServiceCollection services)
    {
        services.AddSingleton<ConvertDomainEventsToOutBoxMessagesInterceptor>();

        return services;
    }
}