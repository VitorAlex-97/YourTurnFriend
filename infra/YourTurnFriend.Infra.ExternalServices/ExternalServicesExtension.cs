using Microsoft.Extensions.DependencyInjection;
using YourTurnFriend.Domain.Contracts.Services.Cryptography;
using YourTurnFriend.Domain.Contracts.Services.SendEmail;
using YourTurnFriend.Infra.ExternalServices.Cryptography;
using YourTurnFriend.Infra.ExternalServices.SendEmail;

namespace YourTurnFriend.Infra.ExternalServices;

public static class ExternalServicesExtension
{
    public static IServiceCollection AddExternalService(this IServiceCollection services)
    {
        services.AddScoped<ICryptographyService, CryptographyService>();
        services.AddScoped<ISendEmailService, SendEmailService>();

        return services;
    }
}