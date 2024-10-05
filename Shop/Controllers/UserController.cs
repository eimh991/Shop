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
        public async Task<IActionResult> Register(UserDTO userDTO)
        {
            await _userService.CreateAsync(userDTO);

            return Ok();
        }

        [Authorize]
        [HttpGet("getme")]
        public async Task<ActionResult<User>> GetingUser()
        {
            var userStringId = HttpContext.User.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.Sid)?.Value;
            if (userStringId == null)
            {
                throw new Exception("Ошибка авторизационных данных");
            }
            int userId = Convert.ToInt32(userStringId);
            var user = await _userService.GetByIdAsync(userId);

            return Ok(user);
        }


        
    }
}
