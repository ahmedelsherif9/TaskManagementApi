using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.DTOs;
using TaskManagement.Repo;

namespace TaskManagement.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountservice;

        public AccountController(IAccountService accountservice)
        {
            _accountservice = accountservice;
        }

        [HttpPost("Api/Account/Signup")]
        public async Task<IActionResult> Signup([FromBody] SignUpDto signUpModel)
        {
            var result = await _accountservice.SignUpAsync(signUpModel);
            if (result != null) 
            {
                return Ok(result);
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost("Api/Account/Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginModel)
        {
            var result = await _accountservice.LoginAsync(loginModel);
            if (result != null)  
            {
                return Ok(result);
            }
            else
            {
                return Unauthorized();
            }
        }
    }

}
