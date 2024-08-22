using Microblog.Api.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microblog.Api.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasKey(u => u.Id);

        builder
            .Property(u => u.Id);

        builder
            .Property(u => u.UserName);

        builder
            .HasIndex(u => u.UserName)
            .IsUnique();

        builder
            .Property(u => u.Senha);
    }
}
