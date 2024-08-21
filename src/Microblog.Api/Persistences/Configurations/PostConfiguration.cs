using Microblog.Api.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microblog.Api.Persistences.Configurations;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder
            .HasKey(p => p.Id);

        builder
            .Property(p => p.Id);

        builder
            .Property(p => p.Titulo);

        builder
            .Property(p => p.Conteudo);

        builder
            .Property(p => p.DataCriacao);

        builder
            .Property(p => p.DataAtualizacao);
    }
}
