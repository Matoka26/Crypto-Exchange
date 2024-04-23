using test_binance_api.Models;

namespace test_binance_api.Repository.CoinRepository
{
    public interface ICoinRepository
    {
        Task<decimal> GetLivePrice(string pair);
        Task<decimal> GetHistoricalPrice(string pair, DateTime date);
        Task<List<decimal>> GetPreviousPrices(string pair, DateTime date, int offset);
        Task<List<decimal>> CalculateLastRSIs(string pair, int offset, int amount);
    }
}
