using AssetHubBlazor.Models;
using System.Diagnostics;

namespace AssetHubBlazor.Services;

public class AssetService
{
    public List<Asset> AssetList { get; private set; } = new();
    private int _nextId = 1;
    public AssetService()
    {
        // Seed with sample data
        AddAsync(new Asset
        {
            Id = 1,
            Name = "Mike",
            Type = AssetType.Laptop,
            Status = Status.InUse,
            AssignedTo = "Alice Johnson",
            PurchaseDate = new DateTime(2023, 5, 10),
            PurchasePrice = 1500,
            SerialNumber = "MBP-12345"
        }).Wait();

        AddAsync(new Asset
        {
            Id = 2,
            Name = "Don",
            Type = AssetType.Monitor,
            Status = Status.Available,
            PurchaseDate = new DateTime(2022, 11, 3),
            PurchasePrice = 300,
            SerialNumber = "MON-67890"
        }).Wait();
    }
    public Task AddAsync(Asset asset)
    {
        // Only assign a new ID if the asset's ID is 0 (default)
        if (asset.Id == 0)
        {
            asset.Id = _nextId++;
        }
        else
        {
            // If a seeded asset has a specific ID, update _nextId to avoid duplicates
            if (asset.Id >= _nextId)
            {
                _nextId = asset.Id + 1;
            }
        }
        Debug.WriteLine("Asset added");
        Debug.WriteLine($"Asset ID: { asset.Id}");
        AssetList.Add(asset);
        return Task.CompletedTask;
    }

    public async Task<Asset?> GetByIdAsync(int id)
    {
        Debug.WriteLine("Searched by ID");
        var asset = AssetList.FirstOrDefault(a => a.Id == id);
        return asset;
    }
}
