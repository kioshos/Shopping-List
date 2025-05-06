using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shopping.Domain.Entities;
using Shopping.Infrastructure.Classes.Configurations;


namespace Shopping.Infrastructure.Classes;

public class ShoppingDbContext : IdentityDbContext<IdentityUser>
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<ShoppingList> ShoppingLists { get; set; }
    public DbSet<PurchaseHistory> PurchaseHistories { get; set; }
    public ShoppingDbContext(DbContextOptions<ShoppingDbContext> options)
        : base(options)
    {
        
    }
    public ShoppingDbContext()
        : base(new DbContextOptionsBuilder<ShoppingDbContext>()
            .UseSqlite("DataSource=Shopping.db") 
            .Options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new ItemConfiguration());
        modelBuilder.ApplyConfiguration(new PurchaseHistoryConfiguration());
        modelBuilder.ApplyConfiguration(new ShoppingLIstConfiguration());
    }
}