using FluentValidation;

namespace Microblog.Api.Dtos;

public record UserLogin
{
    public string UserName { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;
}

public class UserLoginValidator : AbstractValidator<UserLogin>
{
    public UserLoginValidator()
    {
        RuleFor(u => u.UserName)
            .NotEmpty()
            .NotNull();

        RuleFor(u => u.Password)
            .NotEmpty()
            .NotNull();
    }
}