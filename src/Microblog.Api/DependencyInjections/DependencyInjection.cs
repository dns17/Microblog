using FluentValidation;

using Microblog.Api.Abstracts;
using Microblog.Api.Interfaces;
using Microblog.Api.Security;
using Microblog.Api.Services;

using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Microblog.Api.DependencyInjections;

public static class DependencyInjection
{
    public static IServiceCollection AddMicroblogServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddPersistence(configuration);

        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddProblemDetails();

        services.AddServices();
        services.AddValidations();

        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IPostService, PostService>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();

        return services;
    }

    private static IServiceCollection AddValidations(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<Program>();

        return services;
    }

    private static IServiceCollection AddAuthentication(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

        services.AddSingleton<TokenGenerator>();

        services
            .ConfigureOptions<JwtTokenValidationConfiguration>()
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer();

        return services;
    }
}