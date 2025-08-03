using AssetHubBlazor.Models;

namespace AssetHubBlazor.Services;

public class AssetService
{
    public List<Asset> AssetList = new();
    private int _nextId = 1;

    public Task AddAsync(Asset asset)
    {
        asset.Id = _nextId++;
        AssetList.Add(asset);
        return Task.CompletedTask;
    }

    public async Task<Asset?> GetByIdAsync(int id)
    {
        var asset = AssetList.FirstOrDefault(a => a.Id == id);
        return asset;
    }
}
