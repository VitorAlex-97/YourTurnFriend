using MediatR;
using YourTurnFriend.Domain.DomainEvents;
using YourTurnFriend.Domain.SeedWorks;

namespace YourTurnFriend.Application.Wrappers.DomainWrappers;

public class PublisherDomainEvent(IPublisher publisher) : IPublisherDomainEvent
{
    private readonly IPublisher _publisher = publisher;

    public async Task Publish(IDomainEvent domainEvent, CancellationToken cancellationToken = default)
    {
        var notification = CreateNotification(domainEvent);
        await _publisher.Publish(notification, cancellationToken);
    }

    private static INotification CreateNotification(IDomainEvent domainEvent)
    {
        var domainEventType = domainEvent.GetType();
        var notificationType = typeof(DomainEventNotification<>).MakeGenericType(domainEventType);
        return (INotification)Activator.CreateInstance(notificationType, domainEvent);
    }
}