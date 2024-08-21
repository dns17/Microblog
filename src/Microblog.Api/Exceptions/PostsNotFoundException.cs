using System.Net;

namespace Microblog.Api.Exceptions;

public class PostsNotFoundException(string message) : ApplicationException(HttpStatusCode.NotFound, message);