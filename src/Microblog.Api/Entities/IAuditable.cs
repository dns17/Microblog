namespace Microblog.Api.Entities;

public interface IAuditable
{
    public DateTime DataCriacao { get; }
    public DateTime DataAtualizacao { get; }
}