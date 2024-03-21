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


        public async Task<Coin> Trade(string type, string pair, decimal amount)
        {
            type = type.ToUpperInvariant();
            if (type != "BUY" && type != "SELL")
                return null;

            pair = pair.ToUpperInvariant();
            var apiUrl = $"https://api.binance.com/api/v3/ticker/price?symbol={pair}";
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync(apiUrl);
            var priceResponse = await response.Content.ReadFromJsonAsync<Coin>();
            var price = (decimal)priceResponse.Price;
            if (price != 0)
            {
                Coin trade = new Coin
                {
                    Id = new Guid(),
                    Symbol = pair,
                    Price = price,
                    Amount = amount,
                    Field = null,
                    DateTime = DateTime.Now,
                    Type = type,
                    IdHistory = null,
                    History = null

                };

                return trade;
            }
            else return null;

            

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
