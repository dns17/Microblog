namespace Microblog.Api.Abstracts;

public interface IPasswordHasher
{
    string GeneratePassword(string password);
    bool VerifyPassword(string password, string hash);
}