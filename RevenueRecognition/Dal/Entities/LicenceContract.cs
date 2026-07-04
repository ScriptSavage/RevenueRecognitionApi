namespace Dal.Entities;

public class LicenceContract
{
    public long ContractId { get; set; }

    public Customer Customer { get; set; } = null!;
    public long CustomerId { get; set; }

    public SoftwareVersion SoftwareVersion { get; set; }
    public long SoftwareVersionId { get; set; }

    public DateTime ValidFrom { get; set; }
    public DateTime ValidTo { get; set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    public decimal BasePriceInPln{ get; set; }

    
}