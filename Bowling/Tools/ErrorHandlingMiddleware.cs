using System;
using System.Net;
using System.Threading.Tasks;
using Bowling.Tools;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

/// <summary>
///     Catch API's exceptions and display them to the user.
/// </summary>
public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var code = HttpStatusCode.InternalServerError; // 500 if unexpected

        if      (exception is ArgumentOutOfRangeException)     code = HttpStatusCode.NotFound;
        else if (exception is ApplicationException)            code = HttpStatusCode.NotFound;
        else if (exception is Exception)                       code = HttpStatusCode.InternalServerError;

        string errorMessage = exception.Message; 
        if(code == HttpStatusCode.InternalServerError) errorMessage = ErrorMessage.OUR_SIDE; 
        var result = JsonConvert.SerializeObject(new { error = exception.Message });
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;
        return context.Response.WriteAsync(result);
    }
}
