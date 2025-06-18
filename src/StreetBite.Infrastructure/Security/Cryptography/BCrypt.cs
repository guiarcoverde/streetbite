using StreetBite.Domain.Repositories.Security;
using BC = BCrypt.Net.BCrypt;

namespace StreetBite.Infrastructure.Security.Cryptography;

public class BCrypt : IPasswordEncrypt
{
    public string Encrypt(string password)
    {
        string passwordHash = BC.HashPassword(password);
        return passwordHash;
    }

    public bool Verify(string password, string hashedPassword) 
        => BC.Verify(password, hashedPassword);
}