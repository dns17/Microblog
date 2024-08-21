namespace Microblog.Api.Dtos;

public record PostResponse(
    int Id,
    string Titulo,
    string Conteudo,
    DateTime DataCriacao,
    DateTime DataAtualizacao);