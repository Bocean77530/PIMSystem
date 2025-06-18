using PIMSys.DTOs.UserDTOs;
using PIMSys.Models;
namespace PIMSys.Services.Interfaces
{
    public interface IUserService {
        Task<IEnumerable<UserReadDto>> GetAllUsersAsync();
        Task<UserReadDto> GetUserByIdAsync(Guid id);
        Task CreateUserAsync(UserCreateDto userDto);
        Task DeleteUserAsync(Guid id);
        Task<User?> ValidateUserAsync(string email, string password);
        Task<User?> GetByEmailAsync(string email);
    }
}