using Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.Configuration;

public class IndividualCustomerConfiguration :  IEntityTypeConfiguration<IndividualCustomer>
{
    public void Configure(EntityTypeBuilder<IndividualCustomer> builder)
    {
        builder.Property(e=>e.FirstName)
            .HasMaxLength(250)
            .IsRequired();
        
        builder.Property(e => e.LastName)
            .HasMaxLength(250)
            .IsRequired();
        
        builder.Property(e => e.Pesel)
            .HasMaxLength(11)
            .IsRequired();
        
        builder.HasIndex(e=>e.Pesel)
            .IsUnique();
        
    }
}