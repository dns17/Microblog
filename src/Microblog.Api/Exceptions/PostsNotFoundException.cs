using System.Net;

namespace Microblog.Api.Exceptions;

public class PostsNotFoundException(string message) : MicroblogApplicationException(HttpStatusCode.NotFound, message);