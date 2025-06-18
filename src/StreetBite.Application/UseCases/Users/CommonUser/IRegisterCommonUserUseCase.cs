using StreetBite.Communication.Requests;

namespace StreetBite.Application.UseCases.Users.CommonUser;

public interface IRegisterCommonUserUseCase
{
    Task Execute(RequestCreateCommonUserJson requestCreateCommonUserJson);
}