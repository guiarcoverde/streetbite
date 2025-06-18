namespace StreetBite.Domain.Repositories.User.CommonUser;

public interface ICommonUserWriteOnlyRepository
{
    Task Add(Entities.User user);
    Task Delete(Entities.User user);
}