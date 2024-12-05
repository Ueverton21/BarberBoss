using BarberBoss.Communication.Responses;
using BarberBoss.Exception.ExceptionBase;
using BarberBoss.Exception.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BarberBoss.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if(context.Exception is BarberBossException)
        {
            ProjectException(context);
        }
        else
        {
            UnknownError(context);
        }
    }
    private void ProjectException(ExceptionContext context)
    {
        var validationException = (BarberBossException) context.Exception;
        var responseError = new ResponseErrorJson(validationException.Errors);

        if (context.Exception is NotFoundException) {
            context.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
        }
        else if(context.Exception is ValidationException)
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
        
        context.Result = new ObjectResult(responseError);
    }
    private void UnknownError(ExceptionContext context)
    {
        var responseError = new ResponseErrorJson(ResourcesErrorsAttendanceJson.UNKNOWN_ERROR);

        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(responseError);
    }
}
