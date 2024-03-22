using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using test_binance_api.Models;

namespace test_binance_api.Data
{
    public class BinanceContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Coin> Coins { get; set; }
        public DbSet<History> Histories { get; set; }

        public BinanceContext(DbContextOptions<BinanceContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<User>()
                .HasOne(h => h.History)
                .WithOne(u => u.User)
                .HasForeignKey<History>(a => a.IdUser)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<History>()
                .HasMany(c => c.Transactions)
                .WithOne(h => h.History)
                .HasForeignKey(a => a.IdHistory)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }

}
