using AutoMapper;
public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserReadDto>> GetAllUsersAsync()
    {
        var users = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<UserReadDto>>(users);
    }

    public async Task<UserReadDto> GetUserByIdAsync(int id)
    {
        var user = await _repository.GetByIdAsync(id);
        return _mapper.Map<UserReadDto>(user);
    }

    public async Task CreateUserAsync(UserCreateDto userDto)
    {
        var user = _mapper.Map<User>(userDto);
        await _repository.AddAsync(user);
        await _repository.SaveAsync();
    }

    public async Task DeleteUserAsync(int id)
    {
        var user = await _repository.GetByIdAsync(id);
        if (user != null)
        {
            _repository.Remove(user);
            await _repository.SaveAsync();
        }
    }
}