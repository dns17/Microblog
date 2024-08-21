using Microblog.Api.Exceptions;

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;


namespace Microblog.Api.Abstracts;

public sealed class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        ProblemDetails problemDetails = new ProblemDetails()
        {
            Status = StatusCodes.Status500InternalServerError
        };

        if (exception is MicroblogApplicationException applicationException)
        {
            problemDetails.Detail = applicationException.Message;
            problemDetails.Status = (int?)applicationException.Status;
        }

        await httpContext.Response
            .WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}