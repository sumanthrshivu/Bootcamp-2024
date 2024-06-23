using JWTLoginAPI.Interface;

namespace JWTLoginAPI.Services
{
    public class CommonService : ICommonService
    {
        public int checkStatus(bool condition) 
        { 
            return condition ? 200: 500;
        }
    }
}
