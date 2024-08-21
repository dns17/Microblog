using Microblog.Api.Abstracts;
using Microblog.Api.Interfaces;
using Microblog.Api.Services;

namespace Microblog.Api.DependencyInjections;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddPersistence(configuration);

        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddProblemDetails();

        services.AddScoped<IPostService, PostService>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();

        return services;
    }
}