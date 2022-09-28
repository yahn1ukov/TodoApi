using System.Text;
using System.Security.Cryptography;
using TodoApi.Application.Common.Interfaces.Authentication;

namespace TodoApi.Infrastructure.Common.Authentication;

public class PasswordHashGenerator : IPasswordHashGenerator
{
    public void Generate(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        var hmac = new HMACSHA256();

        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }

    public bool Verify(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        var hmac = new HMACSHA256(passwordSalt);

        var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

        return computeHash.SequenceEqual(passwordHash);
    }
}