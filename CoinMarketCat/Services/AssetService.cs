using Clients;
using Domain.Models;
using Domain.Responses;
using Newtonsoft.Json;
using Services.Abstractions;

namespace Services
{
    public class AssetService : IAssetService
    {
        private readonly CoinCapClient _coinCapClient;

        public AssetService(CoinCapClient coinCapClient)
        {
            _coinCapClient = coinCapClient;
        }

        public async Task<Asset> GetAssetById(string assetId)
        {
            var response = await _coinCapClient._httpclient.GetAsync($"assets/{assetId.ToLower()}");
            if (!response.IsSuccessStatusCode)
                return null;

            var content = response.Content.ReadAsStringAsync().Result;

            var result = JsonConvert.DeserializeObject<AssetsByIdResponse>(content);
            return result.Data;
        }

        public async Task<Asset> GetAssetBySymbol(string symbol)
        {            
            using (StreamReader reader = new StreamReader("../../../../Services/assets_overview.json"))
            {
                string json = reader.ReadToEnd();
                var assets = JsonConvert.DeserializeObject<AssetOverviewResponse>(json);
                var assetId = assets.Assets.
                    FirstOrDefault(x => x.Asset_Id != null && x.Asset_Id.ToLower() == symbol.ToLower()).Name.ToLower();
                return await GetAssetById(assetId);
            }
        }

        public async Task<IEnumerable<Asset>> GetPopularAssets()
        {
            var response = await _coinCapClient._httpclient.GetAsync($"assets?limit=10");
            if (!response.IsSuccessStatusCode)
                return null;

            var content = response.Content.ReadAsStringAsync().Result;

            var result = JsonConvert.DeserializeObject<AssetsResponse>(content);
            return result.Data;
        }

        public async Task<IEnumerable<Market>> GetAssetsMarkets(string assetId)
        {
            var response = await _coinCapClient._httpclient.GetAsync($"assets/{assetId.ToLower()}/markets");
            if (!response.IsSuccessStatusCode)
                return null;

            var content = response.Content.ReadAsStringAsync().Result;

            var result = JsonConvert.DeserializeObject<MarketResponse>(content);
            return result.Data
                .Where(x => x.QuoteSymbol == "USDT")
                .DistinctBy(x => x.ExchangeId);
        }

        public async Task<IEnumerable<HistoryData>> GetAssetsHistory(string assetId)
        {
            var response = await _coinCapClient._httpclient.GetAsync($"assets/{assetId.ToLower()}/history?interval=d1");
            if (!response.IsSuccessStatusCode)
                return null;

            var content = response.Content.ReadAsStringAsync().Result;

            var result = JsonConvert.DeserializeObject<HistoryDataResponse>(content);
            return result.Data
                .TakeLast(30);
        }

        public async Task<double?> Convert(string symbol1, string symbol2, double amount)
        {
            var asset1 = await GetAssetBySymbol(symbol1);
            var asset2 = await GetAssetBySymbol(symbol2);
            if (asset1 == null || asset2 == null || amount < 0)
                return null;
            return amount * asset1.PriceUsd / asset2.PriceUsd;
        }
    }
}
