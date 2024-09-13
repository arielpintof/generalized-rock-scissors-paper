using System.Security.Cryptography;
using System.Text;

namespace itransition_task3.Utils;

public static class Crypto
{
    public static byte[] GenerateRandomKey(int keyLength = 32)
    {
        var key = new byte[keyLength];
        RandomNumberGenerator.Fill(key);
        
        return key;
    }

    public static byte[] ComputeHmac(byte[] key, string data)
    {
        using var hmac = new HMACSHA256();
        hmac.Key = key;
        
        return hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
    }
    
    public static byte[] HexStringToByteArray(string hex)
    {
        return Enumerable.Range(0, hex.Length)
            .Where(x => x % 2 == 0)
            .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
            .ToArray();
    }
}