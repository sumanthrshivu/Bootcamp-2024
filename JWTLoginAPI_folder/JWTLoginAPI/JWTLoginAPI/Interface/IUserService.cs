using JWTLoginAPI.Models;
using JWTLoginAPI.Services;

namespace JWTLoginAPI.Interface
{
    public interface IUserService<T>
    {
        Task<UserListResult> GetUserList(UserModel userModel);

        Task<ResultService<T>> UpdateUserAysnc(RegisterModel register);
        Task<ResultService<T>> DeleteUserAysnc(int userid);
        
    }
}
