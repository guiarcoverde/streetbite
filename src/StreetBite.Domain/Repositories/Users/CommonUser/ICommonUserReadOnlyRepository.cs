namespace StreetBite.Domain.Repositories.Users.CommonUser;

public interface ICommonUserReadOnlyRepository
{
    Task<bool> ExistActiveUserWithEmail(string email);
    Task<Entities.Users.CommonUser> GetCommonUserByEmail(string email);
}