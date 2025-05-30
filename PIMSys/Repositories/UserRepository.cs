using Microsoft.EntityFrameworkCore;

public class UserRepository : IUserRepository {
    private readonly AppDbContext _context;
    public UserRepository(AppDbContext context) {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetAllAsync() =>
        await _context.Users.ToListAsync();

    public async Task<User> GetByIdAsync(int id) =>
        await _context.Users.FindAsync(id) ?? throw new KeyNotFoundException($"User with ID {id} not found.");

    public async Task AddAsync(User user) =>
        await _context.Users.AddAsync(user);

    public void Remove(User user) =>
        _context.Users.Remove(user);

    public async Task SaveAsync() =>
        await _context.SaveChangesAsync();
}