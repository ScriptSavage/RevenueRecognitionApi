using Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.Configuration;

public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
{
    public void Configure(EntityTypeBuilder<Discount> builder)
    {
        builder.HasKey(e => e.DiscountId);

        builder.Property(e => e.Name)
            .IsRequired();
        
        builder.Property(e=>e.Percentage)
            .HasPrecision(100,2)
            .IsRequired();
        
        builder.Property(e=>e.ValidFrom)
            .IsRequired();
        
        builder.Property(e=>e.ValidTo)
            .IsRequired();
    }
}