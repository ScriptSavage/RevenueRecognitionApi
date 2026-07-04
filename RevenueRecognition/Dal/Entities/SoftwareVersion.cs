namespace Dal.Entities;

public class SoftwareVersion
{
    public long VersionId { get; set; }

    public Software Software { get; set; }
    public long SoftwareId { get; set; }

    public string VersionNumber { get; set; }
    
    public DateTime ReleaseYear { get; set; }

    public decimal AnnualPriceInPln { get; set; }


    public ICollection<LicenceContract> LicenceContracts { get; set; } = [];
}