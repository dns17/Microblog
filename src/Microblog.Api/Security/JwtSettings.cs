namespace Microblog.Api.Security;

public sealed class JwtSettings
{
    public const string SectionName = "JwtSettings";
    public string Audience { get; init; } = null!;
    public string Issuer { get; init; } = null!;
    public string Secret { get; init; } = null!;
    public int ExpiracaoToken { get; init; }
}