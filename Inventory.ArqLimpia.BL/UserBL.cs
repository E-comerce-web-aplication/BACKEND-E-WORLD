using Inventory.ArqLimpia.EN.Interfaces;
using Inventory.ArqLimpia.BL.Interfaces.Interfaces;
using Inventory.ArqLimpia.BL.DTOs;
using Inventary.ArqLimpia.DAL;
using inventory.ArqLimpia.EN;

namespace Inventory.ArqLimpia.BL
{
    public class UserBL: IUserBL
    {
       readonly IUser userDAL;
        public UserBL(IUser UserDAL)
        {
            userDAL = UserDAL;
        }
       

        public async Task<FindUserOutputDTO> FindUser(int userId)
        {
            var isUser = await userDAL.FindUser(userId);
            if(isUser == null){
                throw new Exception($"User with id: {userId} not found");
            }
            FindUserOutputDTO user = new FindUserOutputDTO(){
                Id = isUser.Id,
                FirstName = isUser.FirstName,
                Surname = isUser.Surname,
                DateOfBirth = isUser.DateOfBirth,
                Email = isUser.Email
            };
            return user;
        }

        public Task FindUser(FindUserInputDTO userId)
        {
            throw new NotImplementedException();
        }

        public async Task<LoginOutputDTO> Login(LoginInputDTO pUser)
        {
            UserEN user = new UserEN(){
                Email= pUser.Email,
                Password = pUser.Password
            };
            UserEN isUserEmail = await userDAL.LoginUser(user);
            if(isUserEmail == null){
                throw new Exception($"User with email: {pUser.Email} not found");   
            }else{
                bool isMatch = BCrypt.Net.BCrypt.Verify(pUser.Password,isUserEmail.Password);
                if(isMatch == false){
                    throw new Exception("Incorrect Password");
                }
            }

            LoginOutputDTO isUser = new LoginOutputDTO(){
                status=true
            };

            return isUser;
        
        }

        public async Task<RegisterUserOutputDTO> Register(RegisterUserInputDTO pUser)
        {
            string passHashed = BCrypt.Net.BCrypt.HashPassword(pUser.Password);
            UserEN user = new UserEN(){
                FirstName = pUser.FirstName,
                Surname = pUser.Surname,
                DateOfBirth = pUser.DateOfBirth,
                Email = pUser.Email,
                Password = passHashed
            };
            userDAL.Register(user);
            RegisterUserOutputDTO User = new RegisterUserOutputDTO(){
                FirstName = user.FirstName,
                Surname = user.Surname,
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
            };
            return User;
        }
    }
}
