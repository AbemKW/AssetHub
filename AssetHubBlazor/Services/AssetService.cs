using AssetHubBlazor.Components.Pages;
using AssetHubBlazor.Models;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AssetHubBlazor.Services;

public class AssetService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public List<Asset> AssetList { get; private set; } = new();
    private int _nextId = 1;
    public AssetService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<List<Asset>> GetAllAsync()
    {
        if (!AssetList.Any())
        {
            await LoadFromJson();
        }
        return AssetList;
    }
    public async Task LoadFromJson()
    {
        var client = _httpClientFactory.CreateClient("AssetServiceClient");
        var jsonContent = await client.GetStringAsync("Data/sample-data.json");
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            Converters = { new JsonStringEnumConverter() } // Use built-in enum converter
        };
        var assets = JsonSerializer.Deserialize<List<Asset>>(jsonContent, options);

        AssetList = assets ?? new();
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

    public Task<Asset?> GetByIdAsync(int id)
    {
        Debug.WriteLine("Searched by ID");
        var asset = AssetList.FirstOrDefault(a => a.Id == id);
        return Task.FromResult(asset);
    }
    public Task UpdateAsync(Asset asset)
    {
        var existing = AssetList.FirstOrDefault(a => a.Id == asset.Id);
        if(existing != null)
        {
            AssetList.Remove(existing);
            AssetList.Add(asset);
        }
        return Task.CompletedTask;
    }

    public Task RemoveAsync(Asset asset)
    {
        AssetList.RemoveAll(a => a.Id == asset.Id);
        return Task.CompletedTask;
    }
}
