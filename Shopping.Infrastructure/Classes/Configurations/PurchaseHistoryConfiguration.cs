using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping.Domain.Entities;

namespace Shopping.Infrastructure.Classes.Configurations;

public class PurchaseHistoryConfiguration : IEntityTypeConfiguration<PurchaseHistory>
{
    public void Configure(EntityTypeBuilder<PurchaseHistory> builder)
    {
        builder.HasKey(ph => ph.Id);
        builder.Property(ph => ph.ShoppingListName).IsRequired();
        builder.Property(ph => ph.Price).IsRequired();
        builder.Property(ph => ph.Quantity).IsRequired();
        builder.Property(ph => ph.PurchaseDate).IsRequired();
        builder.HasOne(ph => ph.Category)
            .WithMany();
        builder.HasOne(ph => ph.ShoppingList)
            .WithMany();
        builder.ToTable("PurchaseHistory");
    }
}