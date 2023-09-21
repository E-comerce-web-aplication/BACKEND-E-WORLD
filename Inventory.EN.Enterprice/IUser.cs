using inventory.ArqLimpia.EN;

namespace Inventory.ArqLimpia.EN.Interfaces
{
    public interface IUser
    {
        Task<UserEN> FindUser(int userId);
        Task<UserEN> LoginUser(UserEN pUser);
        void Register(UserEN pUser);
    }
}
