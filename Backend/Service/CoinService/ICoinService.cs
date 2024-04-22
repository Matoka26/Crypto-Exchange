using test_binance_api.Models;
using test_binance_api.Repository;

namespace test_binance_api.Service.CoinService
{
    public interface ICoinService
    {
        Task<decimal> GetLivePrice(string pair);
        Task<decimal> GetHistoricalPrice(string pair, DateTime date);
        Task<decimal> GetPreviousPrices(string pair, DateTime date, int offset);
        Task<List<decimal>> CalculateLastRSIs(string pair, int offset, int amount);
    }
}
