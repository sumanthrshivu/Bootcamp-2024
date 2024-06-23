using JWTLoginAPI.Interface;
using JWTLoginAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace JWTLoginAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _userDetail;
        private readonly ICommonService _commonService;
        public LoginController(ILoginService userDetail, ICommonService commonService)
        {
            _userDetail = userDetail;
            _commonService = commonService;
        }
        [HttpPost]
        public IActionResult UserLogin(Login userdatils)
        {
            var result = _userDetail.VerifyLogin(userdatils);
            return Ok(StatusCode(_commonService.checkStatus(result)));
           
        }
    }
}
