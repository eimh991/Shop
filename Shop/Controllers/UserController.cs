using Microsoft.AspNetCore.Mvc;
using Shop.DTO;
using Shop.Interfaces;
using Shop.Service;
using Shop.UsersDTO;

namespace Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task<IResult> Register(UserDTO userDTO)
        {
            await _userService.CreateAsync(userDTO);
            
            return Results.Ok();
        }
        
    }
}
