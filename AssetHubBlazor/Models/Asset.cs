namespace AssetHubBlazor.Models;

public class Asset
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public string ModelNumber { get; set; } = string.Empty;
    public string SerialNumber { get; set; } = string.Empty;
    public string Status { get; set; } = "Available";
    public string? AssignedTo { get; set; }
    public string? Department { get; set; }
    public string Location { get; set; } = "Office";
    public DateTime PurchaseDate { get; set; } = DateTime.Now;
    public decimal PurchasePrice { get; set; }
    public int WarrantyYears { get; set; } = 3;
    public string? Notes { get; set; }
}
