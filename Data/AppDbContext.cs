using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using RiskTrack.Models;

namespace RiskTrack.Data {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
        }
        public DbSet<Provider> Providers { get;  set; }
    }
}