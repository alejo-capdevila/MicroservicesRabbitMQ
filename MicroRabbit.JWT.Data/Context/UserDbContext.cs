using MicroRabbit.JWT.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroRabbit.JWT.Data.Context
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}
