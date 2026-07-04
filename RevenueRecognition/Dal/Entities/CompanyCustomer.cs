namespace Dal.Entities;

public class CompanyCustomer : Customer
{
    public string CompanyName { get;  set; } = null!;
    public string Krs { get;  set; } = null!;
}