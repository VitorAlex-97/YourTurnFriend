using MediatR;
using YourTurnFriend.Domain.SeedWorks;

namespace YourTurnFriend.Application.Wrappers.DomainWrappers;

public class DomainEventNotification<TDomainEvent>
(
    TDomainEvent domainEvent
) : INotification where TDomainEvent : IDomainEvent
{
    public TDomainEvent DomainEvent { get; } = domainEvent;
}