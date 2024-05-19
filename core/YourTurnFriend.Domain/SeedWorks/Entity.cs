namespace YourTurnFriend.Domain.SeedWorks;

public abstract class Entity
{
    public string Id { get; }

    protected Entity() => Id = Guid.NewGuid().ToString();

    protected abstract void Validate();
}
