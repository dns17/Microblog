using System.Net;

namespace Microblog.Api.Exceptions;

public abstract class MicroblogApplicationException(
    HttpStatusCode status, string message) : Exception(message)
{
    public HttpStatusCode Status { get; } = status;
}