using Dal.Configuration;
using Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dal.Context;

public class ProjectContext : DbContext
{
    public ProjectContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }  


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        modelBuilder.ApplyConfiguration(new IndividualCustomerConfiguration());
        modelBuilder.ApplyConfiguration(new CompanyCustomerConfiguration());
        modelBuilder.ApplyConfiguration(new SoftwareCategoryConfiguration());
        modelBuilder.ApplyConfiguration(new SoftwareConfiguration());
        modelBuilder.ApplyConfiguration(new DiscountConfiguration());
        modelBuilder.ApplyConfiguration(new LicenceContractConfiguration());
        modelBuilder.ApplyConfiguration(new SoftwareVersionConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}