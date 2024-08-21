using Microblog.Api.Persistences.Contexts;

using Microsoft.EntityFrameworkCore;

namespace Microblog.Api.DependencyInjections;

public static class PersistenceServiceCollection
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
    {

        var connectionString = configuration.GetConnectionString("BloggingContext") ?? throw new InvalidOperationException();

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });

        return services;
    }
}