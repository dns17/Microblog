using FluentValidation;

namespace Microblog.Api.Dtos;

public record PostRequest
{
    public string Titulo { get; set; } = string.Empty;
    public string Conteudo { get; set; } = string.Empty;
}

public class PostRequestValidator : AbstractValidator<PostRequest>
{
    public PostRequestValidator()
    {
        RuleFor(p => p.Titulo)
            .NotEmpty()
            .NotNull();

        RuleFor(p => p.Conteudo)
            .NotEmpty()
            .NotNull();
    }
}