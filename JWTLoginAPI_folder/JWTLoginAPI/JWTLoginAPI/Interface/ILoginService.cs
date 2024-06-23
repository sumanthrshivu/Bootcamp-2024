using JWTLoginAPI.Models;

namespace JWTLoginAPI.Interface
{
    public interface ILoginService
    {
        bool VerifyLogin(Login userdetails);
    }
}
