using Microsoft.Extensions.DependencyInjection;
using YourTurnFriend.Domain.Contracts.Services.Cryptography;
using YourTurnFriend.Infra.ExternalServices.Cryptography;

namespace YourTurnFriend.Infra.ExternalServices;

public static class ExternalServicesExtension
{
    public static IServiceCollection AddExternalService(this IServiceCollection services)
    {
        services.AddScoped<ICryptographyService, CryptographyService>();

        return services;
    }
}