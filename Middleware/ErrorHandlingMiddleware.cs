using System.Net;
using System.Text.Json;

namespace OrderService.Exceptions;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
        
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var code = HttpStatusCode.InternalServerError;
        if (exception is OrderNotFoundException) 
        {
            code = HttpStatusCode.NotFound;
        } 
        else if (exception is OrderExistException) 
        {
            code = HttpStatusCode.Conflict;
        }
        else if (exception is ProductNotFoundException)
        {
            code = HttpStatusCode.NotFound;
        }
        else if (exception is ZeroQuantityException) 
        {
            code = HttpStatusCode.Conflict;
        }
        else if (exception is NegativeOrZeroQuantityException)
        {
            code = HttpStatusCode.Conflict;
        }
        else if (exception is OrderDeletionException) 
        {
            code = HttpStatusCode.Conflict;
        }
        else if (exception is InvalidStatusException)
        {
            code = HttpStatusCode.Conflict;
        }
        var result = JsonSerializer.Serialize(new { error = exception.Message });
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;
        return context.Response.WriteAsync(result);
    }
}
