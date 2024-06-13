using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProductTracker.Domain.AppSetting;
using ProductTracker.Domain.Entity;
using ProductTracker.Domain.Repository;

namespace ProductTracker.Infrastructure.Repository;

internal sealed class JwtManagerRepository(IOptions<JwtOption> options) : IJwtManagerRepository
{
    private readonly JwtOption _config = options.Value;

    public TokenSession GenerateToken(string userName)
    {
        throw new NotImplementedException();
    }

    public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {
        throw new NotImplementedException();
    }

    public TokenSession? GenerateJWTTokens(string userName)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_config.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                [
                    new(ClaimTypes.Name, userName)
                ]),
                Expires = DateTime.Now.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var refreshToken = GenerateRefreshToken();
            return new TokenSession
            {
                AccessToken = tokenHandler.WriteToken(token),
                RefreshToken = refreshToken 
            };
        }
        catch (Exception)
        {
            return null;
        }
    }
}