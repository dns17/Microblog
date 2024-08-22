using System.Net;

namespace Microblog.Api.Exceptions;

public class UserNotAuthorizedException(string message)
    : MicroblogApplicationException(HttpStatusCode.Unauthorized, message);