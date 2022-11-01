using Domain.Entities;

namespace Services.Abstractions
{
    public interface IAssetService
    {
        Task<Asset> GetAssetById(string assetId);
        Task<Asset> GetAssetBySymbol(string symbol);
        Task<IEnumerable<Asset>> GetPopularAssets();
        Task<IEnumerable<Market>> GetAssetsMarkets(string assetId);
        Task<IEnumerable<HistoryData>> GetAssetsHistory(string assetId);        
        Task<double?> Convert(string symbol1, string symbol2, double amount);
    }
}
