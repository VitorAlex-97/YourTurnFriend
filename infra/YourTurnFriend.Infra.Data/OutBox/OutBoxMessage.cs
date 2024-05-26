namespace YourTurnFriend.Infra.Data.OutBox;

public sealed class OutBoxMessage
{
    public Guid Id { get; set; }
    public string Type { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime OcurredOn { get; set; }
    public DateTime? ProcessedOn { get; set; }
}