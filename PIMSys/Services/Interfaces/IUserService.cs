public interface IUserService {
    Task<IEnumerable<UserReadDto>> GetAllUsersAsync();
    Task<UserReadDto> GetUserByIdAsync(int id);
    Task CreateUserAsync(UserCreateDto userDto);
    Task DeleteUserAsync(int id);
}