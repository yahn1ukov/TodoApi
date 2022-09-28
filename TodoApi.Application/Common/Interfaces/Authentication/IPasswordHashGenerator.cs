namespace TodoApi.Application.Common.Interfaces.Authentication;

public interface IPasswordHashGenerator
{
    void Generate(string password, out byte[] passwordHash, out byte[] passwordSalt);
    bool Verify(string password, byte[] passwordHash, byte[] passwordSalt);
}