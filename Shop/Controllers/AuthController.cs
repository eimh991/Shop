using Microsoft.AspNetCore.Mvc;
using Shop.DTO;
using Shop.Interfaces;
using Shop.Service;

namespace Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task<IResult> Login(LoginUserDTO loginUserDTO)
        {
            var token = await ((UserService)_userService).Login(loginUserDTO.Email, loginUserDTO.Password);
            return Results.Ok(token);
            //return Results.Ok( new { token = "Bearer " + token });
        }
    }
}
