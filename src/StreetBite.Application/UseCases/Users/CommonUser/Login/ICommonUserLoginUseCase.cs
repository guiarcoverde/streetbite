using StreetBite.Communication.Requests.CommonUser.Login;

namespace StreetBite.Application.UseCases.Users.CommonUser.Login;

public interface ICommonUserLoginUseCase
{
    Task<ResponseLoginCommonUserJson> Execute(RequestLoginCommonUserJson request);
}