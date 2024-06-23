using JWTLoginAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;
using JWTLoginAPI.Interface;
using BCrypt.Net;

namespace JWTLoginAPI.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly BootcampContext _bootcampContext;
        public RegisterService(BootcampContext bootcampContext)
        {
            _bootcampContext = bootcampContext;

        }
        public void Register(ref bool result, RegisterModel registerModel)
        {
            try
            {
                var registeruser = new Register
                {
                    Firstname = registerModel.Firstname,
                    Lastname = registerModel.Lastname,
                    Email = registerModel.Email,
                    Password = BCrypt.Net.BCrypt.HashPassword(registerModel.Password),
                };
                _bootcampContext.Registers.Add(registeruser);
                result = Convert.ToBoolean(_bootcampContext.SaveChanges());
            }
            catch (Exception)
            {
                result = false;
            }
            
        }
    }
}
