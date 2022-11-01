using Clients;
using Domain.Models;
using Domain.Responses;
using Newtonsoft.Json;
using Services.Abstractions;

namespace Services
{
    public class ExchangeService : IExchangeService
    {
        private readonly CoinCapClient _coinCapClient;

        public ExchangeService(CoinCapClient coinCapClient)
        {
            _coinCapClient = coinCapClient;
        }

        public async Task<Exchange> GetExchangeById(string exchangeId)
        {
            var response = await _coinCapClient._httpclient.GetAsync($"exchanges/{exchangeId.ToLower()}");
            if (!response.IsSuccessStatusCode)
                return null;

            var content = response.Content.ReadAsStringAsync().Result;

            var result = JsonConvert.DeserializeObject<ExchangeResponse>(content);
            return result.Data;
        }
    }
}
