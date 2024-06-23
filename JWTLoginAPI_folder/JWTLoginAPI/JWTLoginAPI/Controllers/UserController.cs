using JWTLoginAPI.Interface;
using JWTLoginAPI.Models;
using JWTLoginAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace JWTLoginAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService<bool> _userService;
        private readonly ICommonService _commonService;
        private readonly ILogger<UserController> _logger;
        private readonly BootcampContext _bootcampContext;
        public UserController(IUserService<bool> userService, ICommonService commonService, BootcampContext bootcampContext, ILogger<UserController> logger)
        {
            _userService = userService;
            _commonService = commonService;
            _bootcampContext = bootcampContext;
            _logger = logger;
        }
        [HttpPost("GetRegisteredUsers")]
        public async Task<IActionResult> GetRegisteredUsers([FromBody] UserModel userModel)
        {
            var result = await _userService.GetUserList(userModel);
            _logger.LogInformation($"user count is {result.TotalUsers}");
            if (result.Success)
            {
                return Ok(new
                {
                    Users = result.Users,
                    UserCount = result.TotalUsers
                });
            }
            else
            {
                throw new Exception(result.ErrorMessage);
            }
        }

        [HttpPut("updateuser")]
        public async Task<IActionResult> UpdateUser(RegisterModel register)
        {
            //if(!ModelState.IsValid)
            //    return BadRequest(ModelState);
            ResultService<bool> result = await _userService.UpdateUserAysnc(register);
            return result.Success ? Ok(result.Data)
                : result.ErrorMessage == "User not found"
                ? NotFound(new { message = result.ErrorMessage })
                : StatusCode(500, new { message = result.ErrorMessage });
        }
        [HttpDelete("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            ResultService<bool> result = await _userService.DeleteUserAysnc(id);
            return result.Success ? Ok(result.Data)
                : result.ErrorMessage == "User not found"
                ? NotFound(new { message = result.ErrorMessage })
                : StatusCode(500, new { message = result.ErrorMessage });
        }
    }
}
