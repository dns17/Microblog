using System.ComponentModel.DataAnnotations;

namespace Microblog.Api.Dtos;

public class UserRequest
{
    [Required]
    public string UserName { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;

    [Required]
    public string ConfirmarSenha { get; set; } = string.Empty;
}