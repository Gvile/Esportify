using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Esportify.Api.Utils;

public static class PasswordHasherUtils
{
    [Obsolete("Obsolete")]
    public static string GenerateSalt()
    {
        var saltBytes = new byte[16];
        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(saltBytes);
        }
        return Convert.ToBase64String(saltBytes);
    }

    public static string HashPassword(string password, string salt)
    {
        return Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: Convert.FromBase64String(salt),
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 10000,
            numBytesRequested: 32));
    }

    public static bool VerifyPassword(string enteredPassword, string storedHash, string storedSalt)
    {
        var hash = HashPassword(enteredPassword, storedSalt);
        return hash == storedHash;
    }
}