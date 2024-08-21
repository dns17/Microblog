namespace Microblog.Api.Entities;

public class Post : Entity, IAuditable
{
    public string Titulo { get; private set; } = string.Empty;
    public string Conteudo { get; private set; } = string.Empty;
    public DateTime DataCriacao { get; private set; }
    public DateTime DataAtualizacao { get; private set; }

    public Post(
        string titulo,
        string conteudo)
    {
        Titulo = titulo.Trim();
        Conteudo = conteudo.Trim();
    }

    public void Update(
        string? titulo = null,
        string? conteudo = null)
    {
        if (!string.IsNullOrEmpty(titulo))
        {
            Titulo = titulo.Trim();
        }

        if (!string.IsNullOrEmpty(conteudo))
        {
            Conteudo = conteudo.Trim();
        }
    }
}