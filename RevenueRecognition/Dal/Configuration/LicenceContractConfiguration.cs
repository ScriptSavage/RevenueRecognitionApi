using Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.Configuration;

public class LicenceContractConfiguration : IEntityTypeConfiguration<LicenceContract>
{
    public void Configure(EntityTypeBuilder<LicenceContract> builder)
    {
        builder.HasKey(e => e.ContractId);

        builder.Property(e => e.ValidFrom)
            .IsRequired();
        
        builder.Property(e => e.ValidTo)
            .IsRequired();
        
        builder.Property(e => e.BasePriceInPln)
            .IsRequired();

        builder.HasOne(e => e.Customer)
            .WithMany(c => c.LicenceContracts)
            .HasForeignKey(e => e.CustomerId);
        
        builder.HasOne(e=>e.SoftwareVersion)
            .WithMany(c => c.LicenceContracts)
            .HasForeignKey(e => e.SoftwareVersionId);
    }
}