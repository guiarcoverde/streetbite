namespace StreetBite.Domain.Repositories.Users.CommonUser;

public interface ICommonUserWriteOnlyRepository
{
    Task Add(Entities.Users.CommonUser commonUser);
    Task Delete(Entities.Users.CommonUser commonUser);
}