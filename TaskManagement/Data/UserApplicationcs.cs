using Microsoft.AspNetCore.Identity;

namespace TaskManagement.Data
{
    public class UserApplication : IdentityUser
    {
        public required string Name { get; set; }
    }
}
