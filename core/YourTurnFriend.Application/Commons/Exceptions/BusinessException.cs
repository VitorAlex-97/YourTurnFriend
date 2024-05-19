using YourTurnFriend.Application.Commons.Constants;

namespace YourTurnFriend.Application.Commons.Exceptions;

public class BusinessException
(
    string message,
    int apiStatusCode = ApiStatusCode.BAD_REQUEST
) : Exception(message)
{
    public override string Message { get; } = message;
    public int ApiStatusCode { get; } = apiStatusCode;
}
