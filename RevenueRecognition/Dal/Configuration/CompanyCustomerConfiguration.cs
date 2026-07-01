using Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.Configuration;

public class CompanyCustomerConfiguration  : IEntityTypeConfiguration<CompanyCustomer>
{
    public void Configure(EntityTypeBuilder<CompanyCustomer> builder)
    {
        builder.Property(e=>e.CompanyName)
            .HasMaxLength(250)
            .IsRequired();
        
        
        builder.Property(e=>e.Krs)
            .HasMaxLength(250)
            .IsRequired();
        
       builder.HasIndex(e=>e.Krs)
           .IsUnique();
    }
}