namespace YourTurnFriend.Application.Commons.Exceptions;

public class ApplicantionException
(
    string message,
    int apiStatusCode
) : Exception(message)
{
    public override string Message { get; } = message;
    public int ApiStatusCode { get; } = apiStatusCode;
}
