namespace YourTurnFriend.Domain.Exceptions;

public class DomainExceptionValidation : Exception
{
    private DomainExceptionValidation(string message) : base(message) { }
    public static void When(bool isFail, string message)
    {
        if (isFail)
        {
            throw new DomainExceptionValidation(message);
        }
    }
}
