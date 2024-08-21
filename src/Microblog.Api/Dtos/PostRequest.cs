using System.ComponentModel.DataAnnotations;

namespace Microblog.Api.Dtos;

public record PostRequest
{
    [Required]
    public string Titulo { get; set; } = string.Empty;

    [Required]
    public string Conteudo { get; set; } = string.Empty;
}