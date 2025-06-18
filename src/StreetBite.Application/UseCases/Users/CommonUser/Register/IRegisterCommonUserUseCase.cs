using StreetBite.Communication.Requests.CommonUser.Register;

namespace StreetBite.Application.UseCases.Users.CommonUser.Register;

public interface IRegisterCommonUserUseCase
{
    Task Execute(RequestCreateCommonUserJson requestCreateCommonUserJson);
}