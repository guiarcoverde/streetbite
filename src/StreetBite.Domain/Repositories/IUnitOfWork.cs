namespace StreetBite.Domain.Repositories;

public interface IUnitOfWork
{
    Task Commit();
}