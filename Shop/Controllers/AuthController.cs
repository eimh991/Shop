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
        public async Task<ActionResult> Login(LoginUserDTO loginUserDTO)
        {
            var token = await ((UserService)_userService).Login(loginUserDTO.Email, loginUserDTO.Password);
            HttpContext.Response.Cookies.Append("test-cookie", token);
            return Ok();
            //return Ok( new { token = "Bearer " + token });
        }
    }
}
