using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Microblog.Api.Abstracts;
using Microblog.Api.Dtos;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Microblog.Api.Security;

public class TokenGenerator(
    IOptions<JwtSettings> jwtOptions,
    IDateTimeProvider dateTimeProvider)
{
    private readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;
    private readonly JwtSettings _jwtSettings = jwtOptions.Value;

    public string Generate(int userId, string userName)
    {
        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
        SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        List<Claim> claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Name, userName),
            new("id", userId.ToString())
        };

        DateTime expired = _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiracaoToken);
        JwtSecurityToken jwtToken = new JwtSecurityToken(
            _jwtSettings.Issuer,
            _jwtSettings.Audience,
            claims,
            expires: expired,
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler()
            .WriteToken(jwtToken);
    }
}