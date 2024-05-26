using YourTurnFriend.Domain.SeedWorks;

namespace YourTurnFriend.Domain.DomainEvents;

public interface IPublisherDomainEvent
{
    Task Publish(IDomainEvent domainEvent, CancellationToken cancellationToken = default);
    
}