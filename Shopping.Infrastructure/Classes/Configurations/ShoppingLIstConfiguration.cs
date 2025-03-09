using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping.Domain.Entities;

namespace Shopping.Infrastructure.Classes.Configurations;

public class ShoppingLIstConfiguration : IEntityTypeConfiguration<ShoppingList>
{
    public void Configure(EntityTypeBuilder<ShoppingList> builder)
    {
        builder.HasKey(shl => shl.Id);
        builder.Property(shl => shl.Id).ValueGeneratedOnAdd();
        builder.Property(shl => shl.CreatedDate).IsRequired();
        builder.HasMany(itm => itm.Items)
            .WithOne(i => i.ShoppingList);
        builder.ToTable("ShoppingList");
    }
}