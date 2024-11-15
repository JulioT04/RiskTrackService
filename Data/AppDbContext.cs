using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using RiskTrack.Models;

namespace RiskTrack.Data {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
        }
        public DbSet<Provider> Providers { get;  set; }
        public DbSet<User> Users { get;  set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Provider>()
            .HasOne(p => p.User)
            .WithMany(u => u.Providers)
            .HasForeignKey(p => p.UserId);
    }
    }
}