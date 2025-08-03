using System.ComponentModel.DataAnnotations;

namespace AssetHubBlazor.Models;

public enum AssetType
{
    Phone,
    Laptop,
    Monitor,
    Desktop,
    Tablet,
    Peripheral,
    Wearable,
    SmartDevice,
    Headphones,
    Headset,
    Keyboard,
    Mouse
}
public enum Status
{
    Available,
    InUse,
    InRepair
}
public class Asset
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required(ErrorMessage = "Type is required.")]
    public AssetType Type { get; set; }
    public string Brand { get; set; } = string.Empty;
    public string ModelNumber { get; set; } = string.Empty;
    public string SerialNumber { get; set; } = string.Empty;
    [Required]
    public Status Status { get; set; }
    public string? AssignedTo { get; set; }
    public string? Department { get; set; }
    public string Location { get; set; } = "Office";
    [Required]
    public DateTime PurchaseDate { get; set; } = DateTime.Now;
    public decimal PurchasePrice { get; set; }
    public int WarrantyYears { get; set; } = 3;
    public string? Notes { get; set; }
}
