using StreetBite.Domain.Entities;
using StreetBite.Domain.Repositories.User;
using StreetBite.Domain.Repositories.User.CommonUser;
using StreetBite.Infrastructure.Identity;

namespace StreetBite.Infrastructure.DataAccess.Repositories;

public class CommonUserRepository(StreetBiteDbContext dbContext) : ICommonUserWriteOnlyRepository
{
    private readonly StreetBiteDbContext _dbContext = dbContext;

    public async Task Add(User user)
    {
        var appUser = ApplicationUser.FromDomain(user);
        await _dbContext.Users.AddAsync(appUser);
    }

    public async Task Delete(User user)
    {
    }
}