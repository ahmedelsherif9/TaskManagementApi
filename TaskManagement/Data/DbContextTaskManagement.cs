using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TaskManagement.Data
{
    public class DbContextTaskManagement : IdentityDbContext<UserApplication>
    {
        public DbContextTaskManagement(DbContextOptions<DbContextTaskManagement> options)
        : base(options)
        {
        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskComment> TaskComments { get; set; }

    }
}