namespace YourTurnFriend.Domain.SeedWorks;

public abstract class Auditable
{
    public DateTime CreatedAt { get; private set; }
    public DateTime? LastUpdatedAt { get; protected set; }
}