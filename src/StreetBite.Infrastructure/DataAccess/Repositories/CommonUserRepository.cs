using StreetBite.Domain.Entities.Users;
using StreetBite.Domain.Repositories.Users.CommonUser;
using StreetBite.Infrastructure.Identity;

namespace StreetBite.Infrastructure.DataAccess.Repositories;

public class CommonUserRepository(StreetBiteDbContext dbContext) : ICommonUserWriteOnlyRepository
{
    private readonly StreetBiteDbContext _dbContext = dbContext;

    public async Task Add(CommonUser commonUser)
    {
        var appUser = ApplicationUser.FromDomain(commonUser);
        await _dbContext.Users.AddAsync(appUser);
    }

    public async Task Delete(CommonUser commonUser)
    {
    }
}