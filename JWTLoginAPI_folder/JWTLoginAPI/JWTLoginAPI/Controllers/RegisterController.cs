using JWTLoginAPI.Interface;
using JWTLoginAPI.Models;
using JWTLoginAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTLoginAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly BootcampContext _bootcampContext;
        private readonly IRegisterService _registerService;
        private readonly ICommonService _commonService;
        public RegisterController(BootcampContext bootcampContext, IRegisterService registerService, ICommonService commonService)
        {
            _bootcampContext = bootcampContext;
            _registerService = registerService;
            _commonService = commonService;
        }
        [HttpPost("Register")]
        public IActionResult RegisterUser([FromBody]RegisterModel registerModel) 
        {
            if(!ModelState.IsValid)
                return BadRequest("please provide the proper details");
            if (_bootcampContext.Registers.Any(R => R.Email == registerModel.Email))
                return BadRequest("Email is already registered");

            bool result = false;
           _registerService.Register(ref result,registerModel);
            return Ok(_commonService.checkStatus(result));

        }

    }
}
