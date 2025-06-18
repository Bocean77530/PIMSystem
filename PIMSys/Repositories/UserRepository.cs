using Microsoft.EntityFrameworkCore;
using PIMSys.Models;
using PIMSys.Data;
using PIMSys.Repositories.Interfaces;
namespace PIMSys.Repositories
{
    public class UserRepository : IUserRepository {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context) {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllAsync() =>
            await _context.Users.ToListAsync();

        public async Task<User> GetByIdAsync(Guid id) =>
            await _context.Users.FindAsync(id) ?? throw new KeyNotFoundException($"User with ID {id} not found.");

        public async Task<User?> GetByEmailAsync(string email) =>
            await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

        public async Task AddAsync(User user) =>
            await _context.Users.AddAsync(user);

        public void Remove(User user) =>
            _context.Users.Remove(user);

        public async Task SaveAsync() =>
            await _context.SaveChangesAsync();
    }
}