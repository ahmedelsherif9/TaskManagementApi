using Microsoft.AspNetCore.Identity;
using TaskManagement.DTOs;

namespace TaskManagement.Repo
{
    public interface IAccountService
    {
        public Task<IdentityResult> SignUpAsync(SignUpDto signUpModel);
        public Task<string> LoginAsync(LoginDto loginModel);
    }
}
