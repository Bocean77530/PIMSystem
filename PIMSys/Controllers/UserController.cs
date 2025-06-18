using Microsoft.AspNetCore.Mvc;
using PIMSys.DTOs.UserDTOs;
using PIMSys.Services.Interfaces;

namespace PIMSys.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public UserController(IUserService userService, ITokenService tokenService) {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserReadDto>>> GetUsers() =>
            Ok(await _userService.GetAllUsersAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<UserReadDto>> GetUser(Guid id) {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(UserCreateDto dto) {
            await _userService.CreateUserAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(Guid id) {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] LoginDto dto) {
            var user = await _userService.ValidateUserAsync(dto.Email, dto.Password);
            if (user == null) return Unauthorized("Invalid credentials");
            var token = _tokenService.GenerateToken(user.Id);
            return Ok(token);
        }
    }
}