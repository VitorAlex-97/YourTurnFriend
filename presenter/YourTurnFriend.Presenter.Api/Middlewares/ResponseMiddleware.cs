using System.Net;
using YourTurnFriend.Application.Commons.Exceptions;
using YourTurnFriend.Application.Commons.Wrappers;
using YourTurnFriend.Domain.Exceptions;

namespace YourTurnFriend.Presenter.Api.Middlewares;

public class ResponseMiddleware
{
    private readonly RequestDelegate _next;

    public ResponseMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
         try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            await HandleException(context, exception);
        }
    }

    private async Task HandleException(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        // int status = (int)HttpStatusCode.InternalServerError;
        // string message = $"Infelizmente ocorreu um erro inesperado";

        var (statusCode, message) = ExtractResponseFromException(exception);

        // switch (exception)
        // {
        //     case ApplicantionException:
        //         status = (int)HttpStatusCode.BadRequest;
        //         message = exception.Message;
        //         break;
        //     case DomainExceptionValidation:
        //         status = (int)HttpStatusCode.UnprocessableEntity;
        //         message = exception.Message;
        //         break;
        // };

        var response = Response<object>.Fail(new(), message);

        context.Response.StatusCode = statusCode;
        await context.Response.WriteAsJsonAsync(response);
    }

    private (int statusCode, string message) ExtractResponseFromException(Exception exception) 
        => exception switch
        {
            BusinessException => (((BusinessException)exception).ApiStatusCode, exception.Message),
            DomainExceptionValidation => ((int)HttpStatusCode.UnprocessableEntity, exception.Message),
            _ => ((int)HttpStatusCode.InternalServerError, $"Infelizmente ocorreu um erro inesperado")
        };
    
}