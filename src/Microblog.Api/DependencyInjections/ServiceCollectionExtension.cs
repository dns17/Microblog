using FluentValidation;

using Microblog.Api.Abstracts;
using Microblog.Api.Interfaces;
using Microblog.Api.Persistence.Contexts;
using Microblog.Api.Persistence.Interceptions;
using Microblog.Api.Security;
using Microblog.Api.Services;

using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Microblog.Api.DependencyInjections;

public static class ServiceCollectionExtension
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
        services.AddAuthentication(configuration);

        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IPostService, PostService>();
        services.AddScoped<IUserService, UserService>();

        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddSingleton<TokenGenerator>();

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
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName) ?? throw new InvalidOperationException());

        services.AddSingleton<TokenGenerator>();

        services
            .ConfigureOptions<JwtTokenValidationConfiguration>()
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer();

        return services;
    }

    private static IServiceCollection AddPersistence(
       this IServiceCollection services,
       IConfiguration configuration)
    {

        var connectionString = configuration.GetConnectionString("BloggingContext") ?? throw new InvalidOperationException();

        services.AddDbContext<AppDbContext>((sp, options) =>
        {
            options
                .UseNpgsql(connectionString)
                .AddInterceptors(sp.GetRequiredService<AuditableInterception>());
        });

        services.AddScoped<AuditableInterception>();

        return services;
    }
}