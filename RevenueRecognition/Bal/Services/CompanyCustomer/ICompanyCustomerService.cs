using Bal.Dto;

namespace Bal.Services.CompanyCustomer;

public interface ICompanyCustomerService
{
    Task AddCustomerAsync(CompanyCustomerDto.CompanyCustomer request);
    
    Task DeleteCustomerAsync(long id);
    
    Task UpdateCustomerAsync(long id, CompanyCustomerDto.UpdateCompanyCustomerDto request);
    
    Task<CompanyCustomerDto.CompanyCustomer> GetCustomerAsync(long id);
}