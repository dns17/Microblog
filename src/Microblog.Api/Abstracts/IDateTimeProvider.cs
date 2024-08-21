namespace Microblog.Api.Abstracts;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}