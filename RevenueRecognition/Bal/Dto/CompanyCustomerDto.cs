namespace Bal.Dto;

public static class CompanyCustomerDto
{
    public record CompanyCustomer(
        string City,
        string Street,
        string PostalCode,
        string PhoneNumber,
        string Email,
        string KRS,
        string CompanyName);
    
    public record UpdateCompanyCustomerDto(
        string City,
        string Street,
        string PostalCode,
        string PhoneNumber,
        string Email,
        string CompanyName);
}