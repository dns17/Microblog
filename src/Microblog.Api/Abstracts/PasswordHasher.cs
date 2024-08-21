using static BCrypt.Net.BCrypt;

namespace Microblog.Api.Abstracts;

public sealed class PasswordHasher : IPasswordHasher
{
    public string GeneratePassword(string password)
    {
        return HashPassword(password);
    }

    public bool VerifyPassword(string password, string hash)
    {
        return Verify(password, hash);
    }
}
