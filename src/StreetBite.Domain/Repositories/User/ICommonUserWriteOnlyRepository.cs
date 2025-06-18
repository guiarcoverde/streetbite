namespace StreetBite.Domain.Repositories.User;

public interface ICommonUserWriteOnlyRepository
{
    Task Add(Entities.User user);
    Task Delete(Entities.User user);
}