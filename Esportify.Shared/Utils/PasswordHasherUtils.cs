using System.Security.Cryptography;
using System.Text;

namespace Esportify.Shared.Utils;

public static class PasswordHasherUtils
{
    //public static string HashPassword(string password)
    //{
    //    using (var sha256 = SHA256.Create())
    //    {
    //        var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
    //        return Convert.ToBase64String(bytes);
    //    }
    //}
    
    public static string HashPassword(string password)
    {
        // Créer une instance de SHA256
        using (SHA256 sha256 = SHA256.Create())
        {
            // Convertir le mot de passe en bytes
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            
            // Convertir les bytes en chaîne hexadécimale pour une représentation lisible
            StringBuilder builder = new StringBuilder();
            foreach (byte b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }
            return builder.ToString();
        }
    }

    public static bool VerifyPassword(string password, string storedHash)
    {
        var hashOfInput = HashPassword(password);
        return hashOfInput == storedHash;
    }
}