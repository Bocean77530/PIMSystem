using AutoMapper;
using PIMSys.DTOs.UserDTOs;
using PIMSys.Models;

namespace PIMSys.Mappers
{
    public class UserProfile : Profile {
        public UserProfile() {
            // Model ➝ DTO
            CreateMap<User, UserReadDto>();

            // DTO ➝ Model
            CreateMap<UserCreateDto, User>();
        }
    }
}