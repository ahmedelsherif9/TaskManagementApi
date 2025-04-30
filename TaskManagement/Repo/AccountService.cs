using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskManagement.Data;
using TaskManagement.DTOs;

namespace TaskManagement.Repo
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<UserApplication> _userManager;
        private readonly SignInManager<UserApplication> _signInManager;
        private readonly IConfiguration _config;

        public AccountService(UserManager<UserApplication> userManager, SignInManager<UserApplication> signInManager, IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
        }

        public async Task<IdentityResult> SignUpAsync(SignUpDto signUpModel)
        {
            var user = new UserApplication()
            {
                Name = signUpModel.Name,
                Email = signUpModel.Email,
                UserName = signUpModel.Email

            };
            return await _userManager.CreateAsync(user, signUpModel.Password);

        }




        public async Task<string> LoginAsync(LoginDto loginModel)
        {
            var result = await _signInManager.PasswordSignInAsync(loginModel.Email, loginModel.Password, false, false);
            if (result.Succeeded)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var AuthClaims = new[] {
                    new Claim(ClaimTypes.Name , loginModel.Email),
                    new Claim(JwtRegisteredClaimNames.Email, loginModel.Email),
                    new Claim(JwtRegisteredClaimNames.Typ, loginModel.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
                var token = new JwtSecurityToken(
                    issuer: _config["Jwt:Issuer"],
                    audience: _config["Jwt:Audience"],
                    claims: AuthClaims,
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: credentials);

                return new JwtSecurityTokenHandler().WriteToken(token);

            }

            return "You Have To Enter Correct Email an Password";


        }
    }
}


