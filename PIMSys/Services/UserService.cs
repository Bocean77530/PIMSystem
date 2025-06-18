using AutoMapper;
using PIMSys.DTOs.UserDTOs;
using PIMSys.Models;
using PIMSys.Repositories.Interfaces;
using PIMSys.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace PIMSys.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserService(IUserRepository repository, IMapper mapper, IPasswordHasher<User> passwordHasher)
        {
            _repository = repository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task<IEnumerable<UserReadDto>> GetAllUsersAsync()
        {
            var users = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserReadDto>>(users);
        }

        public async Task<UserReadDto> GetUserByIdAsync(Guid id)
        {
            var user = await _repository.GetByIdAsync(id);
            return _mapper.Map<UserReadDto>(user);
        }

        public async Task CreateUserAsync(UserCreateDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            user.Id = Guid.NewGuid();
            user.Password = _passwordHasher.HashPassword(user, userDto.Password);
            await _repository.AddAsync(user);
            await _repository.SaveAsync();
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user != null)
            {
                _repository.Remove(user);
                await _repository.SaveAsync();
            }
        }

        public async Task<User?> ValidateUserAsync(string email, string password)
        {
            var user = await _repository.GetByEmailAsync(email);
            if (user == null) return null;

            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, password);
            return result == PasswordVerificationResult.Success ? user : null;
        }

        public async Task<User?> GetByEmailAsync(string email) =>
            await _repository.GetByEmailAsync(email);
    }
}