using StreetBite.Communication.Requests.CommonUser.Login;
using StreetBite.Domain.Services.Login.CommonUser;

namespace StreetBite.Application.UseCases.Users.CommonUser.Login;

public class CommonUserLoginUseCase(ICommonUserLoginService service) : ICommonUserLoginUseCase
{
    private readonly ICommonUserLoginService _service = service;
    
    public async Task<ResponseLoginCommonUserJson> Execute(RequestLoginCommonUserJson request)
    {
        var response = await _service.LoginAsync(request.Email, request.Password);
        
        return new ResponseLoginCommonUserJson
        {
            Message = "Login successful",
            AccessToken = response.AccessToken
        };
    }
}