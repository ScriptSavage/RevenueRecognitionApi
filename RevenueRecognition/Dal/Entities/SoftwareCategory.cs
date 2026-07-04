namespace Dal.Entities;

public class SoftwareCategory
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;

    public ICollection<Software> Software { get; set; } = [];
}