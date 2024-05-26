using MediatR;
using YourTurnFriend.Application.Wrappers.DomainWrappers;
using YourTurnFriend.Domain.Contracts.Services.SendEmail;
using YourTurnFriend.Domain.DomainEvents.User;

namespace YourTurnFriend.Application.ProcessDomainEvents.User;

public class CreateUserDomainEventHandler 
    : INotificationHandler<DomainEventNotification<UserCreatedDomainEvent>>
{
    private readonly ISendEmailService _sendEmailService;

    public CreateUserDomainEventHandler(ISendEmailService sendEmailService)
    {
        _sendEmailService = sendEmailService;
    }

    public async Task Handle(DomainEventNotification<UserCreatedDomainEvent> notification, CancellationToken cancellationToken)
    {

        await _sendEmailService.Send(new SendEmailRequest
        {
            Email = "userEmail@email.com",
            Sender = "One that send Email",
            Title = "Title of email that will be send"
        });
    }
}