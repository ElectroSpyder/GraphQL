namespace CommanderGQL.Data
{
    using CommanderGQL.Models;
    using Microsoft.EntityFrameworkCore;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Platform> Platforms { get; set; }
    }
}