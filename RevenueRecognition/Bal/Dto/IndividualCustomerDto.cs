namespace Bal.Dto;

public static class IndividualCustomerDto
{
    public record CreateNewIndividualCustomer(string City,
        string Street,
        string PostalCode,
        string PhoneNumber,
        string Email,
        string FirstName, 
        string LastName,
        string Pesel);


    public record Response(
        string Email,
        string FirstName,
        string LastName);


    public record UpdateIndividualCustomer(
        string City,
        string Street,
        string PostalCode,
        string PhoneNumber,
        string Email,
        string FirstName,
        string LastName);
}