using test_binance_api.Models;
using test_binance_api.Repository.CoinRepository;

namespace test_binance_api.Service.CoinService
{
    public class CoinService : ICoinService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ICoinRepository _coinRepository;

        public CoinService(ICoinRepository coinRepository, IHttpClientFactory clientFactory)
        {
            _coinRepository = coinRepository;
            _clientFactory = clientFactory;
        }

        public async Task<decimal> GetLivePrice(string pair)
        {
            pair = pair.ToUpperInvariant();
            var apiUrl = $"https://api.binance.com/api/v3/ticker/price?symbol={pair}";
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync(apiUrl);
            var priceResponse = await response.Content.ReadFromJsonAsync<Coin>();

            return priceResponse.Price;
        }

    }
}
