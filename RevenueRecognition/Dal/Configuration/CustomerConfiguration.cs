using Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.Configuration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasDiscriminator<string>("CustomerType")
            .HasValue<IndividualCustomer>("IndividualCustomer")
            .HasValue<CompanyCustomer>("CompanyCustomer");


        builder.HasKey(e => e.CustomerId);
        
        
        builder.Property(e=>e.Email)
            .HasMaxLength(250)
            .IsRequired();
        
        builder.HasIndex(e=>e.Email)
            .IsUnique();
        
        builder.Property(e=>e.PhoneNumber)
            .HasMaxLength(150)
            .IsRequired();
        
        builder.HasIndex(e=>e.PhoneNumber)
            .IsUnique();
        
        
        builder.Property(e=>e.City)
            .HasMaxLength(250)
            .IsRequired();
        
        builder.Property(e=>e.Street)
            .HasMaxLength(250)
            .IsRequired();
        
        builder.Property(e=>e.PostalCode)
            .HasMaxLength(6)
            .IsRequired();
        
    }
}