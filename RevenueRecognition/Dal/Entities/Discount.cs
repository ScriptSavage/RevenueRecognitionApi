namespace Dal.Entities;

public class Discount
{
    public long DiscountId { get; set; }

    public Software Software { get; set; }
    public long SoftwareId { get; set; }

    public string Name { get; set; }
    
    public decimal Percentage { get; set; }


    public DateTime ValidFrom { get; set; }
    public DateTime ValidTo { get; set; }

    public bool IsValid(DateTime date) =>  date.Date >= ValidFrom.Date && date.Date <= ValidTo.Date;
}