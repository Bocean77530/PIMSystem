namespace PIMSys.DTOs.UserDTOs
{
    public class UserCreateDto {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}