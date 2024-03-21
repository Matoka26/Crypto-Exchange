using test_binance_api.Models;

namespace test_binance_api.Repository.CoinRepository
{
    public interface ICoinRepository
    {
        Task<decimal> GetLivePrice(string pair);
        Task<Coin> Trade(string type, string pair, decimal amount);
    }
}
