using inventory.ArqLimpia.EN;
using Inventory.ArqLimpia.EN.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Inventary.ArqLimpia.DAL
{
    public class UserDAL : IUser
    {
        readonly InventoryContextDAL dbContext;

        public UserDAL(InventoryContextDAL pdbContext)
        {
            dbContext = pdbContext;
        }

        public async Task<UserEN> FindUser(int userId)
        {
            UserEN user = await dbContext.Users.FindAsync(userId);
            return user;
        }

        public async Task<UserEN> LoginUser(UserEN pUser)
        {
            UserEN user = await dbContext.Users.SingleOrDefaultAsync(p => p.Email == pUser.Email);
            return user;
        }

        public async void Register(UserEN pUser)
        {
            await dbContext.Users.AddAsync(pUser);

        }
    }
}
