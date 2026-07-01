namespace Dal.Entities;

public class IndividualCustomer : Customer
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;

    public string Pesel { get; set; } = null!;
    
    public bool IsDeleted { get; set; }
    
    public DateTime? DeletedAtUtc { get; set; }


    public IndividualCustomer(string email, string phoneNumber, string city, string street,
        string postalCode, string firstName, string lastName, string pesel) 
        : base(email, phoneNumber, city, street, postalCode)
    {
        FirstName = firstName;
        LastName = lastName;
        Pesel = pesel;
    }

   


    public IndividualCustomer()
    {
    }

    public void ChangeCustomerData(string email, string phoneNumber, string city, string street,
        string postalCode, string firstName, string lastName)
    {
        if(string.IsNullOrWhiteSpace(email)) Email = email;
        if(string.IsNullOrWhiteSpace(phoneNumber)) PhoneNumber = phoneNumber;
        if(string.IsNullOrWhiteSpace(city)) City = city;
        if(string.IsNullOrWhiteSpace(street)) Street = street;
        if(string.IsNullOrWhiteSpace(postalCode)) PostalCode = postalCode;
        if(string.IsNullOrWhiteSpace(firstName)) FirstName = firstName;
        if(string.IsNullOrWhiteSpace(lastName)) LastName = lastName;
    }

    public override string ToString()
    {
        return $"IndividualCustomer: {FirstName}, {LastName}, {Pesel}";
    }
}