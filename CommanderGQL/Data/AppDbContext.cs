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
        public DbSet<Command> Commands { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Platform>()
                .HasMany(x => x.Commands)
                .WithOne(x => x.Platform!)
                .HasForeignKey(x => x.PlatformId);

            builder.Entity<Command>()
                .HasOne(x => x.Platform)
                .WithMany(x => x.Commands)
                .HasForeignKey(x => x.PlatformId);


        }
    }
}