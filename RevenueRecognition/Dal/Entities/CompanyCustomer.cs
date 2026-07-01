namespace Dal.Entities;

public class CompanyCustomer : Customer
{
    public string CompanyName { get; private set; } = null!;
    public string Krs { get; private set; } = null!;
}