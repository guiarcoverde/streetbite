using Microsoft.AspNetCore.Mvc;
using StreetBite.Application.UseCases.Users.CommonUser;
using StreetBite.Application.UseCases.Users.CommonUser.Login;
using StreetBite.Application.UseCases.Users.CommonUser.Register;
using StreetBite.Communication.Requests;
using StreetBite.Communication.Requests.CommonUser.Login;
using StreetBite.Communication.Requests.CommonUser.Register;

namespace StreetBite.Api.Controllers;

[Route("v1/user")]
[ApiController]
public class CommonUserController : ControllerBase
{
    [HttpPost]
    [Route("register")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromServices] IRegisterCommonUserUseCase useCase,
        [FromBody] RequestCreateCommonUserJson requestCreateCommonUserJson)
    {
        await useCase.Execute(requestCreateCommonUserJson);
        return NoContent();
    }
    
    [HttpPost]
    [Route("login")]
    [ProducesResponseType(typeof(ResponseLoginCommonUserJson),StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Login([FromServices] ICommonUserLoginUseCase useCase,
        [FromBody] RequestLoginCommonUserJson requestLoginCommonUserJson)
    {
        var response = await useCase.Execute(requestLoginCommonUserJson);
        return Ok(response);
    }
}