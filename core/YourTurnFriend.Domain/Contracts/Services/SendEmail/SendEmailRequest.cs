namespace YourTurnFriend.Domain.Contracts.Services.SendEmail;

public sealed class SendEmailRequest
{
    public string Sender { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty ;
}