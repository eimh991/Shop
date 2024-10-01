using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.DTO;
using Shop.Interfaces;
using Shop.Model;
using Shop.Service;
using Shop.UsersDTO;
using System.Security.Claims;

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

        [HttpGet]
        public async Task<IResult> GetingUser()
        {
            var user = await getUser();
            Console.WriteLine(user.Email);

            return Results.Ok();
        }

        private async Task<User> getUser()
        {
            var userStringId = HttpContext.User.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.Sid)?.Value;
            if (userStringId == null)
            {
                throw new Exception("Ошибка авторизационных данных");
            }
            int userId = Convert.ToInt32(userStringId);
            var user = await _userService.GetByIdAsync(userId);
            return user;
        }
        
    }
}
