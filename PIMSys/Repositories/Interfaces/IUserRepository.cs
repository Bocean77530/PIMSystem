public interface IUserRepository {
    Task<IEnumerable<User>> GetAllAsync();
    Task<User> GetByIdAsync(int id);
    Task AddAsync(User user);
    void Remove(User user);
    Task SaveAsync();
}