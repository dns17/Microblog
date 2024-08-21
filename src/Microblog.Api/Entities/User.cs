namespace Microblog.Api.Entities;

public class User : Entity
{
    public string UserName { get; private set; } = string.Empty;
    public string Senha { get; private set; } = string.Empty;
}