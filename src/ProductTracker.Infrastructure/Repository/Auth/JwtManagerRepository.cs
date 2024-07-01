using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProductTracker.Domain.AppSetting;
using ProductTracker.Domain.Repository;

namespace ProductTracker.Infrastructure.Repository.Auth;

/// <inheritdoc cref="IJwtManagerRepository"/>
internal sealed class JwtManagerRepository(
    IOptions<JwtOption> options) : IJwtManagerRepository
{
    private readonly JwtOption _config = options.Value;

    public string GenerateAccessToken(string userLogin)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.ASCII.GetBytes(_config.Key);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = _config.Issuer,
            Audience = _config.Audience,
            Subject = new ClaimsIdentity(
            [
                new Claim(ClaimTypes.Name, userLogin)
            ]),
            Expires = DateTime.Now.AddMinutes(_config.ExpiresInMinutes),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }
}