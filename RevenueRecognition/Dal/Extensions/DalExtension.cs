using Dal.Context;
using Dal.Repositories.Customers;
using Dal.Repositories.UnitWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dal.Extensions;

public static class DalExtension
{
    public static void AddDataAccessLayer(this IServiceCollection service, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("DefaultConnection");

        service.AddDbContext<ProjectContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });


        service.AddScoped<IIndividualCustomerRepository, IndividualCustomerRepository>();
        service.AddScoped<ICompanyCustomerRepository, CompanyCustomerRepository>();
        service.AddScoped<IUnitOfWork, UnitOfWork>();

    }
}