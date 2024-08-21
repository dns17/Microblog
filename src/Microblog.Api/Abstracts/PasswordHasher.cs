namespace Microblog.Api.Abstracts;

public sealed class PasswordHasher : IPasswordHasher
{
    public string GeneratePassword(string password)
    {
        return BC.HashPassword(password);
    }

    public bool VerifyPassword(string password, string hash)
    {
        return BC.Verify(password, hash);
    }
}
