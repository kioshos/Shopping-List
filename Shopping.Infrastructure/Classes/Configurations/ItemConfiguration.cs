using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping.Domain.Entities;

namespace Shopping.Infrastructure.Classes.Configurations;

public class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.HasKey(item => item.Id);
        builder.Property(item => item.Name).IsRequired();
        builder.Property(item => item.Price).IsRequired();
        builder.Property(item => item.Quantity).IsRequired();
        builder.Property(item => item.IsPurchased).HasDefaultValue(false);
        builder.HasOne(item => item.Category)
            .WithMany(c => c.Items);
        builder.HasOne(item => item.ShoppingList)
            .WithMany(list => list.Items);
        builder.ToTable("Item");
    }
}