namespace StreetBite.Domain.Services.Login.CommonUser;

public interface ICommonUserLoginService
{
    Task<ResponseLoginJson> LoginAsync(string email, string password);
}