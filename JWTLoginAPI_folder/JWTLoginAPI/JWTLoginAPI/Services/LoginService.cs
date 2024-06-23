using JWTLoginAPI.Interface;
using JWTLoginAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JWTLoginAPI.Services
{
    public class LoginService : ILoginService
    {
        private readonly BootcampContext _context;

        public LoginService(BootcampContext context)
        {
            _context = context;
        }
        public bool VerifyLogin(Login userdetails)
        {
            bool rowsaffected = false;
            try
            {
              var user=this._context.Registers
                  .FirstOrDefault(user => user.Email == userdetails.Email);
                if (user != null) 
                {
                   rowsaffected = Convert.ToBoolean(BCrypt.Net.BCrypt.Verify(userdetails.Password, user.Password));
                }
                return rowsaffected;
            }
            catch (Exception)
            {

                return rowsaffected;
            }
          
        }
    }
}
