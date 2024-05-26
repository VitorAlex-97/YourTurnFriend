namespace YourTurnFriend.Domain.Contracts.Services.SendEmail;

public interface ISendEmailService
{
    Task Send(SendEmailRequest request);
}