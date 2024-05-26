using YourTurnFriend.Domain.Contracts.Services.SendEmail;

namespace YourTurnFriend.Infra.ExternalServices.SendEmail;

public sealed class SendEmailService : ISendEmailService
{
    public async Task Send(SendEmailRequest request)
    {
        await Task.Run(() => Console.WriteLine($"Enviando email para o usuário em: {DateTime.Now}"));
    }
}