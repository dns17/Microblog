using FluentValidation;

namespace Microblog.Api.Dtos;

public record UserRequest
{
    public string UserName { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string ConfirmarSenha { get; set; } = string.Empty;
}

public class UserRequestValidator : AbstractValidator<UserRequest>
{
    public UserRequestValidator()
    {
        RuleFor(u => u.UserName)
            .NotEmpty()
            .NotNull();

        RuleFor(u => u.Password)
            .NotEmpty()
            .NotNull();

        RuleFor(u => u.ConfirmarSenha)
            .Equal(u => u.Password);
    }
}