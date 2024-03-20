using test_binance_api.Repository;

namespace test_binance_api.Service.CoinService
{
    public interface ICoinService
    {
        public Task<decimal> GetLivePrice(string pair);
    }
}
