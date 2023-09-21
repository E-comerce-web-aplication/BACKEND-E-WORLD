using Inventory.ArqLimpia.BL.DTOs;

namespace Inventory.ArqLimpia.BL.Interfaces.Interfaces
{
    public interface IUserBL
    {
        Task<LoginOutputDTO> Login(LoginInputDTO pUser);

        Task<FindUserOutputDTO> FindUser(int userId);
        
        Task<RegisterUserOutputDTO> Register(RegisterUserInputDTO pUser);
        Task FindUser(FindUserInputDTO userId);
    }
}