using Microsoft.AspNetCore.Mvc;
using StreetBite.Communication.Requests;

namespace StreetBite.Api.Controllers;

[Route("v1/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody]RequestCreateUserJson user)
    {
        return Created();
    }
}