using System.Net;
using System.Text.Json;
using TodoApi.Application.Common.Exception.Base;

namespace TodoApi.Api.Middleware;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch(CustomException ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    public static Task HandleExceptionAsync(HttpContext context, CustomException ex)
    {
        var code = ex.Code switch 
        {
            400 => HttpStatusCode.BadRequest,
            404 => HttpStatusCode.NotFound,
            _ => HttpStatusCode.InternalServerError
        };

        var result = JsonSerializer.Serialize
        (
            new 
            {
                code = code,
                message = ex.Message,
                timestamp = DateTime.Now
            }
        );

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;

        return context.Response.WriteAsync(result);
    }
}