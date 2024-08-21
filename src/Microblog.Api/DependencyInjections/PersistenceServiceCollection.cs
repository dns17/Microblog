using Microblog.Api.Persistences.Contexts;
using Microblog.Api.Persistences.Interceptions;

using Microsoft.EntityFrameworkCore;

namespace Microblog.Api.DependencyInjections;

public static class PersistenceServiceCollection
{
    public static IServiceCollection AddPersistence(
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