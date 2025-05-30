using AutoMapper;


public class UserProfile : Profile {
    public UserProfile() {
        // Model ➝ DTO
        CreateMap<User, UserReadDto>();

        // DTO ➝ Model
        CreateMap<UserCreateDto, User>();
    }
}