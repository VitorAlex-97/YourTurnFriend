using YourTurnFriend.Domain.SeedWorks;

namespace YourTurnFriend.Domain.DomainEvents.User;

public class UserCreatedDomainEvent : IDomainEvent
{
    public Guid UserId { get; }

    public UserCreatedDomainEvent(Guid userId)
    {
        UserId = userId;
    }
}