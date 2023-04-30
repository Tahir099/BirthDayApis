using BirthDay.Model;
using Microsoft.EntityFrameworkCore;

namespace BirthDay.Repository
{
    public class ApiDbContext:DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }
        public DbSet<User> users { get; set; }
    }
}
