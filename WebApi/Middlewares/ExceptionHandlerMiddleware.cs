using Core.Models;
using Npgsql;
using System.Net;
using System.Text.Json;

namespace WebApi.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private const string _contentType = "application/json";

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (InvalidOperationException sqlEx)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = _contentType;
            var Error = new ErrorModel
            {
                Message = sqlEx.InnerException?.InnerException?.Message ??
                    "Ocurrió un error inesperado en la base de datos.",
            };

            var ErrorJson = JsonSerializer.Serialize(Error);
            await context.Response.WriteAsync(ErrorJson);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = _contentType;
            var Error = new ErrorModel
            {
                Message = ex.Message,
            };

            var ErrorJson = JsonSerializer.Serialize(Error);
            await context.Response.WriteAsync(ErrorJson);
        }
    }

}
