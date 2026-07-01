namespace Dal.Entities;

public class Customer
{
    public long CustomerId { get; set; }
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;

    public string City { get; set; } = null!;
    public string Street { get; set; } = null!;
    public string PostalCode { get;  set; } = null!;

    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

    public Customer(string email, string phoneNumber, string city, string street, string postalCode)
    {
        Email = email;
        PhoneNumber = phoneNumber;
        City = city;
        Street = street;
        PostalCode = postalCode;
    }


    public Customer()
    {
    }



    public override string ToString()
    {
        return $"Customer: {CustomerId}, {Email}, {PhoneNumber}, {City}, {Street}, {PostalCode}";
    }
}