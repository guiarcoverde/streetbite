namespace StreetBite.Domain.Repositories.Security;

public interface IPasswordEncrypt
{
    string Encrypt(string password);
    bool Verify(string password, string hashedPassword);
}