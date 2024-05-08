using System.Security.Cryptography;
using System.Text;

namespace DoacaoViva.Domain.helper;
public class EncryptAndDecrypt {
    public static string Decrypt(string password) {
        return string.Empty; 
    }

    public static string Encrypt(string password) {
        using var sHA256 = SHA256.Create();
        byte[] bytes = sHA256.ComputeHash(Encoding.UTF8.GetBytes(password));
        var builder = new StringBuilder();
        for (int i = 0; i < bytes.Length; i++) { 
            builder.Append(bytes[i].ToString("x2"));
        }
        return builder.ToString();
    }

}

