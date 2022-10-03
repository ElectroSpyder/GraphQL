using Microsoft.EntityFrameworkCore;

namespace GrapfQL.Core.Models
{
    public partial class UserDbContext : DbContext
    {
        public UserDbContext()
        {
        }
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }
        public virtual DbSet<User>? Users { get; set; } = null;

    }
}
