using PIMSys.DTOs.UserDTOs;
using PIMSys.Models;
namespace PIMSys.Services.Interfaces
{
    public interface ITokenService
    {
        /// <summary>
        /// Generates a JWT token for the specified user.
        /// </summary>
        /// <param name="userId">The ID of the user for whom the token is generated.</param>
        /// <returns>A string representing the generated JWT token.</returns>
        string GenerateToken(Guid userId);
    }
}