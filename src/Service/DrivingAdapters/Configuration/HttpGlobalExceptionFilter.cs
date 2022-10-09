using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Service.DrivingAdapters.Configuration;

public class HttpGlobalExceptionFilter : IExceptionFilter
{
    private readonly ILogger<HttpGlobalExceptionFilter> _logger;

    public HttpGlobalExceptionFilter(ILogger<HttpGlobalExceptionFilter> logger)
    {
        _logger = logger;
    }

    public void OnException(ExceptionContext context)
    {
        int code = StatusCodes.Status500InternalServerError;

        switch (context.Exception)
        {
            case PandaNotFoundException _:
                {
                    code = (int)HttpStatusCode.NotFound;
                    break;
                }
            default:
                break;
        }
        _logger.LogWarning(context.Exception, "Handled exception thrown");

        context.Result = new ObjectResult(
            new
            {
                context.Exception.Message,
                Code = $"{code}"
            }
        );
        context.HttpContext.Response.StatusCode = code;

        context.ExceptionHandled = true;
    }
}
