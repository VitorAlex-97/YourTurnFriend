namespace YourTurnFriend.Application.Commons.Wrappers;

public readonly struct Response<TData>
{
    public bool IsSuccess { get; }
    public string? Message { get; } = string.Empty;
    public TData? Data { get; }

    private Response(TData? data, string? message = default, bool isSuccess = true)
    {
        Data = data;
        IsSuccess = isSuccess;
        Message = message;
    }

    public static Response<TData> Success(TData? data, string? message = default) 
        => CreateSuccess(data, message);
    public static Response<TData> Fail(TData? data, string? message = default) 
        => CreateFail(data, message);

    private static Response<TData> CreateSuccess(TData? data, string? message = default) 
        => new(data, message, true);

    private static Response<TData> CreateFail(TData? data, string? message = default) 
        => new(data, message, false);
}
