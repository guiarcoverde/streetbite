using Microsoft.AspNetCore.Mvc;
using StreetBite.Application.UseCases.Users.CommonUser;
using StreetBite.Communication.Requests;

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
}