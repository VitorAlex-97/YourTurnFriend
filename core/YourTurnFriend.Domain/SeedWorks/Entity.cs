namespace YourTurnFriend.Domain.SeedWorks;

public abstract class Entity
{
    public Guid Id { get; }

    protected Entity() => Id = Guid.NewGuid();

    protected abstract void Validate();
}
