using Newtonsoft.Json.Linq;
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


        public async Task<decimal> GetHistoricalPrice(string pair, DateTime date)
        {

            pair = pair.ToUpperInvariant();

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://api.binance.com/");



                    string startTime = ((DateTimeOffset)date).ToUnixTimeMilliseconds().ToString();
                    string endTime = ((DateTimeOffset)date.AddDays(1)).ToUnixTimeMilliseconds().ToString();
                    string queryString = $"symbol={pair}&interval=1d&startTime={startTime}&endTime={endTime}&limit=1";


                    string requestUrl = $"api/v3/klines?{queryString}";


                    HttpResponseMessage response = await client.GetAsync(requestUrl);
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();


                    JArray jsonArray = JArray.Parse(responseBody);

                    if (jsonArray.Count == 0)
                    {
                        throw new Exception("No data available for the specified date.");
                    }


                    decimal bitcoinPrice = (decimal)jsonArray[0][4];

                    return bitcoinPrice;
                }
            }
            catch (HttpRequestException e)
            {
                throw new Exception($"HTTP Error: {e.Message}");
            }


        }


        public async Task<decimal> GetPreviousPrices(string pair, DateTime date, int offset)
        {
            List<decimal> prices = new List<decimal>();

            for (int i = 0; i < offset; i++)
            {
                var price = await GetHistoricalPrice(pair, date);
                date = date.AddDays(-1);
                prices.Add(price);
            }

            return await CalculateRSI(prices);
/*
            return prices;*/
        }



        public async Task<decimal> CalculateRSI(List<decimal> prices)
        {

            List<decimal> changes = new List<decimal>();
            for (int i = 0; i < prices.Count - 1; i++)
            {
                changes.Add(prices[i + 1] - prices[i]);
            }

            List<decimal> gains = changes.Select(x => Math.Max(x, 0)).ToList();
            List<decimal> losses = changes.Select(x => Math.Max(-x, 0)).ToList();

            decimal avgGain = gains.Average();
            decimal avgLoss = losses.Average();

            decimal rs;
            if (avgLoss == 0)
            {
                rs = 0;
            }
            else
            {
                rs = avgGain / avgLoss;
            }

            decimal rsi = 100 - (100 / (1 + rs));
            return rsi;
        }


        public async Task<List<decimal>> CalculateLastRSIs(string pair, int offset, int amount)
        {
            List<decimal> values = new List<decimal>();
            /* DateTime date = DateTime.Now;
             var prices = await GetPreviousPrices(pair, date, offset);
             date.AddDays(-offset);

             var value = await CalculateRSI(prices);
             values.Add(value);
             if (amount == 1)
                 return values;
             else
             {
                 for (int i = 0; i < amount - 1; i++)
                 {
                     prices.RemoveAt(0);
                     prices.Add(await GetHistoricalPrice(pair, date));
                     value = await CalculateRSI(prices);
                     values.Add(value);
                     date.AddDays(-1);
                 }

             }

             return prices;*/
            return values;
        }


    }
}

