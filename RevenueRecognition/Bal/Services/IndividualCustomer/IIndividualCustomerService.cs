using Bal.Dto;

namespace Bal.Services.IndividualCustomer;

public interface IIndividualCustomerService
{
    Task<IndividualCustomerDto.Response> AddCompanyCustomerAsync(IndividualCustomerDto.CreateNewIndividualCustomer request);
    
    Task DeleteCustomerAsync(long id);
    
    Task UpdateCustomerAsync(long id, IndividualCustomerDto.UpdateIndividualCustomer request);
}