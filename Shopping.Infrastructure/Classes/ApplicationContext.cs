using Microsoft.EntityFrameworkCore;
using Shopping.Domain.Entities;
using Shopping.Infrastructure.Classes.Configurations;

namespace Shopping.Infrastructure.Classes;

public class ApplicationContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<ShoppingList> ShoppingLists { get; set; }
    public DbSet<PurchaseHistory> PurchaseHistories { get; set; }
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new ItemConfiguration());
        modelBuilder.ApplyConfiguration(new PurchaseHistoryConfiguration());
        modelBuilder.ApplyConfiguration(new ShoppingLIstConfiguration());
    }
}