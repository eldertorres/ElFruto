using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public class AppDbContext : DbContext, IDbContext
    {
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetPrecision(18);
                property.SetScale(6);
            }
            
            modelBuilder.Entity<User>().HasData
            (
                new User
                {
                    Id = -1,
                    Email = "admin@pineapple.com",
                    Username = "admin",
                    Password = "badpass"
                },
                new User
                {
                    Id = -2,
                    Email = "user@pineapple.com",
                    Username = "user",
                    Password = "pass"
                }
            );
            
            base.OnModelCreating(modelBuilder);
        }


        public new async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
        
        public DbSet<Fruit> Fruits { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<User> Users { get; set; }

    }
}