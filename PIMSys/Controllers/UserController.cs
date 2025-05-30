using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase {
    private readonly IUserService _userService;

    public UserController(IUserService userService) {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserReadDto>>> GetUsers() =>
        Ok(await _userService.GetAllUsersAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<UserReadDto>> GetUser(int id) {
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
    public async Task<ActionResult> DeleteUser(int id) {
        await _userService.DeleteUserAsync(id);
        return NoContent();
    }
}