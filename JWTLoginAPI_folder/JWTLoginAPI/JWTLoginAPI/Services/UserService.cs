using JWTLoginAPI.Interface;
using JWTLoginAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace JWTLoginAPI.Services
{
    public class UserService<T> : IUserService<T>
    {
        #region initials
        private readonly BootcampContext _bootcampContext;
        private readonly ILogger<UserService<T>> _logger;

        public UserService(BootcampContext bootcampContext, ILogger<UserService<T>> logger)
        {
            _bootcampContext = bootcampContext;
            _logger = logger;
        }
        #endregion

        #region SerachUser
        public async Task<UserListResult> GetUserList(UserModel userModel)
        {
            var result = new UserListResult();
            try
            {
                _logger.LogInformation("enter into GetUserList method");
                var searchString = userModel.searchstring ?? string.Empty;
                var userQuery = _bootcampContext.Registers.AsQueryable()
                    .Where(e => (e.Firstname ?? string.Empty).Contains(searchString) ||
                    (e.Lastname ?? string.Empty).Contains(searchString) ||
                    (e.Email ?? string.Empty).Contains(searchString));

                int totalusers = await userQuery.CountAsync();
                result.TotalUsers = totalusers;
                _logger.LogInformation($"total count of the user is {totalusers}");

                var userlits = await userQuery.OrderByDescending(i => i.Id)
                    .Skip((int)((userModel.pageNumber - 1) * userModel.pageSize))
                    .Take(userModel.pageSize)
                    .ToListAsync();

                result.Users=userlits;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.ErrorMessage=ex.Message;
                _logger.LogError($"Internal server error, {ex}");
            }
            return result;
        }
        #endregion

        #region UpdateUser
        public async Task<ResultService<T>> UpdateUserAysnc(RegisterModel register)
        {
            var result = new ResultService<T>(); 

            try
            {
                _logger.LogInformation("enter into UpdateUserAysnc method");
                var existinguser = await _bootcampContext.Registers.FindAsync(register.Id);
                if (existinguser == null)
                {
                    return ResultService<T>.FailureResult("User not found");
                }
                else
                {
                    existinguser.Firstname = register.Firstname;
                    existinguser.Lastname = register.Lastname;
                    existinguser.Email = register.Email;

                    _bootcampContext.Registers.Update(existinguser);
                    await _bootcampContext.SaveChangesAsync();
                    result.Success = true;
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = $"Internal server error, {ex}";
                result.Success = false;
                _logger.LogError($"Internal server error, {ex}");
            }
            return result;
        }
        #endregion
        public async Task<ResultService<T>> DeleteUserAysnc(int userid)
        {
            var result = new ResultService<T>();

            try
            {
                _logger.LogInformation("enter into UpdateUserAysnc method");
                var existinguser = await _bootcampContext.Registers.FindAsync(userid);
                if (existinguser == null)
                {
                    return ResultService<T>.FailureResult("User not found");
                }
                else
                {
                    _bootcampContext.Registers.Remove(existinguser);
                    await _bootcampContext.SaveChangesAsync();
                    result.Success = true;
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = $"Internal server error, {ex}";
                result.Success = false;
                _logger.LogError($"Internal server error, {ex}");
            }
            return result;
        }
        #region updateuser<T>
        //public async Task<ResultService<T>> UpdateUserAysnc(RegisterModel register)
        //{
        //    try
        //    {
        //        var existinguser = await _bootcampContext.Registers.FindAsync(register.Id);

        //        if (existinguser == null)
        //            return ResultService<T>.FailureResult("User not found");

        //        existinguser.Firstname = register.Firstname;
        //        existinguser.Lastname = register.Lastname;
        //        existinguser.Email = register.Email;

        //        _bootcampContext.Registers.Update(existinguser);
        //        await _bootcampContext.SaveChangesAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        return ResultService<T>.FailureResult($"Internal server error, {ex}");
        //    }
        //    return ResultService<RegisterModel>.SuccessResult(existinguser);
        //}
        #endregion
    }
}
