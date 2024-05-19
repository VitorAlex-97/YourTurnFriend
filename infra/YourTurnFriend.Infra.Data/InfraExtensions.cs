using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YourTurnFriend.Domain.Contracts;
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
        
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(connection));

        return services;
    }
}