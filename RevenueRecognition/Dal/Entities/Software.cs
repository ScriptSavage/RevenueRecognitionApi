namespace Dal.Entities;

public class Software
{
    public long LicenceId { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Version { get; set; } = null!;

    public SoftwareCategory SoftwareCategory { get; set; }
    public long CategoryId { get; set; }


    public ICollection<SoftwareVersion> SoftwareVersions { get; set; } = [];
    public ICollection<Discount> Discounts { get; set; } = [];
    
}
