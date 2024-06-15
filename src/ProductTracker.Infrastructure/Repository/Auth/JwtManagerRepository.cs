using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using LinqToDB;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProductTracker.Domain.AppSetting;
using ProductTracker.Domain.Repository;
using ProductTracker.Infrastructure.Db;

namespace ProductTracker.Infrastructure.Repository.Auth;

internal sealed class JwtManagerRepository(
    IOptions<JwtOption> options,
    DatabaseQueryWrapper queryWrapper) : IJwtManagerRepository
{
    private readonly JwtOption _config = options.Value;
    private readonly DatabaseQueryWrapper _queryWrapper = queryWrapper;

    public string GenerateAccessToken(string userLogin)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.UTF8.GetBytes(_config.Key);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
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

    public async Task<string> GenerateRefreshToken(string oldRefreshToken)
    {
        var userId = await _queryWrapper.ExecuteAsync(async db =>
        {
            var oldTokenRecord =
                await db.UserXrefRefreshTokens.FirstOrDefaultAsync(x => x.RefreshToken == oldRefreshToken);
            return oldTokenRecord?.UserId ?? throw new AuthenticationException($"No such refresh token: {oldRefreshToken}");
        });

        var newRefreshToken = CreateRefreshToken();
        
        await _queryWrapper.ExecuteAsync(async db =>
        {
            await db.UserXrefRefreshTokens.Where(x => x.UserId == userId)
                .Set(x=> x.RefreshToken, newRefreshToken)
                .UpdateAsync();

            return true;
        });

        return newRefreshToken;
    }

    private static string CreateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    } 
}