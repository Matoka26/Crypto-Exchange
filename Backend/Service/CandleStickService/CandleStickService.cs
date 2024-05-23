using test_binance_api.Models;
using test_binance_api.Repository.CandleStickRepository;

namespace test_binance_api.Service.CandleStickService
{
    public class CandleStickService : ICandleStickService
    {
        public ICandleStickRepository _candleStickRepository { get; set; }

        public CandleStickService(ICandleStickRepository candleStickRepository)
        {
            _candleStickRepository = candleStickRepository;
        }

        public async Task<CandleStick>? GetCandleStickData(string pair, string interval, DateTime startDate)
        {
            var candle = await _candleStickRepository.GetCandleStickData(pair, interval, startDate);
            return candle;
        }

        public async Task<List<CandleStick>>? GetAllCandles(string pair, string interval, DateTime startDate, DateTime endDate)
        {
            var candles = await _candleStickRepository.GetAllCandles(pair, interval, startDate, endDate);
            return candles;
        }

    }
}
