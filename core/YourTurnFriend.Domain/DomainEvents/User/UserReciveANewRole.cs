using YourTurnFriend.Domain.SeedWorks;

namespace YourTurnFriend.Domain.DomainEvents.User;

public record UserReciveANewRole(Guid UserId, Guid RoleId) : IDomainEvent;