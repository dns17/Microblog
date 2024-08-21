using System.Net;

namespace Microblog.Api.Exceptions;

public abstract class ApplicationException(
    HttpStatusCode status, string message) : Exception(message)
{
    public HttpStatusCode Status { get; } = status;
}