using test_binance_api.Models;
using test_binance_api.Repository.CoinRepository;

namespace test_binance_api.Service.CoinService
{
    public class CoinService : ICoinService
    {

        private readonly ICoinRepository _coinRepository;

        public CoinService(ICoinRepository coinRepository, IHttpClientFactory clientFactory)
        {
            _coinRepository = coinRepository;
        }

        public async Task<decimal> GetLivePrice(string pair)
        {
            var price = await _coinRepository.GetLivePrice(pair);
            return price;
        }

        public async Task<decimal> GetHistoricalPrice(string pair, DateTime date)
        {
            var price = await _coinRepository.GetHistoricalPrice(pair, date);
            return price;
        }

    }
}
