using PIMSys.Models;
namespace PIMSys.Repositories.Interfaces
{
    public interface IUserRepository {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(Guid id);
        Task<User?> GetByEmailAsync(string email);
        Task AddAsync(User user);
        void Remove(User user);
        Task SaveAsync();
    }
}