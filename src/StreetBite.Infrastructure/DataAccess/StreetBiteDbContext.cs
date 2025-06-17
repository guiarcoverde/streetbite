using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StreetBite.Domain.Entities;
using StreetBite.Infrastructure.Identity;

namespace StreetBite.Infrastructure.DataAccess;

public class StreetBiteDbContext(DbContextOptions options) : IdentityDbContext<ApplicationUser>(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
