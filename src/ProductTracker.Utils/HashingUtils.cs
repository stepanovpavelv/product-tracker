using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Text;

namespace ProductTracker.Utils;

public static class HashingUtils
{
    public static string GetPasswordHash(string key, string? password)
    {
        ArgumentException.ThrowIfNullOrEmpty(password, nameof(password));

        var salt = Encoding.UTF8.GetBytes(key);

        return Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password!,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));
    }
}