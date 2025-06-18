using StreetBite.Domain.Entities.Users;

namespace StreetBite.Domain.Security.Tokens;

public interface IAccessTokenGenerator
{
    Task<string> GenerateAccessTokenAsync(CommonUser user, IList<string> roles);
}