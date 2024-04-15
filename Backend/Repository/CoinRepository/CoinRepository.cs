using test_binance_api.Models;

namespace test_binance_api.Repository.CoinRepository
{
    public class CoinRepository : ICoinRepository
    {
        public readonly IHttpClientFactory _clientFactory;

        public CoinRepository(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }


        public async Task<decimal> GetLivePrice(string pair)
        {
            pair = pair.ToUpperInvariant();
            var apiUrl = $"https://api.binance.com/api/v3/ticker/price?symbol={pair}";
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync(apiUrl);
            var priceResponse = await response.Content.ReadFromJsonAsync<Coin>();

            return (decimal)priceResponse.Price;
        }
    }
}
