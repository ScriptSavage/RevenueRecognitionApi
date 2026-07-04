using Bal.Dto;
using Bal.Services.CompanyCustomer;
using Bal.Services.IndividualCustomer;
using Bal.Validators.CompanyCustomerValidators;
using Bal.Validators.IndividualCustomerValidators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Bal.Extensions;

public static class BusinessAccessLayerExtension
{
    public static void AddBusinessAccessLayer(this IServiceCollection services)
    {
        services.AddScoped<IValidator<IndividualCustomerDto.CreateNewIndividualCustomer>, CreateNewIndividualCustomerValidator>();
        services.AddScoped<IValidator<CompanyCustomerDto.CompanyCustomer>, CreateNewCompanyCustomerValidator>();
        
        
        services.AddScoped<IIndividualCustomerService, IndividualCustomerService>();
        services.AddScoped<ICompanyCustomerService, CompanyCustomerService>();
    }
}