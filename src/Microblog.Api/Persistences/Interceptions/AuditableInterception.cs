using Microblog.Api.Abstracts;
using Microblog.Api.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Microblog.Api.Persistences.Interceptions;

public sealed class AuditableInterception(IDateTimeProvider dateTimeProvider) : SaveChangesInterceptor
{
    private readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        if (eventData.Context is not null)
        {
            UpdateProperties(eventData.Context);
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        if (eventData.Context is not null)
        {
            UpdateProperties(eventData.Context);
        }

        return base.SavingChanges(eventData, result);
    }

    private void UpdateProperties(DbContext context)
    {
        DateTime utcNow = _dateTimeProvider.UtcNow;

        var entities = context.ChangeTracker
            .Entries<IAuditable>()
            .ToList();

        foreach (var entry in entities)
        {
            if (entry.State is EntityState.Added)
            {
                SetCurrentPropertyValue(
                    entry,
                    nameof(IAuditable.DataCriacao),
                    utcNow);
            }

            if (entry.State is EntityState.Added or EntityState.Modified)
            {
                SetCurrentPropertyValue(
                    entry,
                    nameof(IAuditable.DataAtualizacao),
                    utcNow);
            }
        }
    }

    static void SetCurrentPropertyValue(
        EntityEntry entry,
        string propertyName,
        DateTime utcNow) =>
        entry.Property(propertyName).CurrentValue = utcNow;
}