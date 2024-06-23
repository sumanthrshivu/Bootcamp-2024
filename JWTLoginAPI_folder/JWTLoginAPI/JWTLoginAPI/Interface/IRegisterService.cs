using JWTLoginAPI.Models;

namespace JWTLoginAPI.Interface
{
    public interface IRegisterService
    {
        void Register(ref bool result,RegisterModel registerModel);
    }
}
