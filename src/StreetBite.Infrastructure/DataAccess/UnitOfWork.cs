using StreetBite.Domain.Repositories;

namespace StreetBite.Infrastructure.DataAccess;

internal class UnitOfWork(StreetBiteDbContext dbContext) : IUnitOfWork
{
    public async Task Commit() => await dbContext.SaveChangesAsync();
}