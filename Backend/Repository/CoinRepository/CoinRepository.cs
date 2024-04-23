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

                    Console.WriteLine(date.Day);
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


                    decimal historicalPrice = (decimal)jsonArray[0][4];

                    return historicalPrice;
                }
            }
            catch (HttpRequestException e)
            {
                throw new Exception($"HTTP Error: {e.Message}");
            }


        }


        public async Task<List<decimal>> GetPreviousPrices(string pair, DateTime date, int offset)
        {
            List<decimal> prices = new List<decimal>();

            for (int i = 0; i < offset; i++)
            {
                var price = await GetHistoricalPrice(pair, date);
                date = date.AddDays(-1);
                prices.Add(price);
            }


            return prices;
        }



        public async Task<decimal> CalculateRSI(List<decimal> prices)
        {

            if (prices == null || prices.Count < 2)
                throw new ArgumentException("Invalid prices data.");

            decimal gainSum = 0;
            decimal lossSum = 0;

            // Calculate initial gain and loss
            for (int i = 1; i < prices.Count; i++)
            {
                decimal priceDiff = prices[i] - prices[i - 1];
                if (priceDiff >= 0)
                    gainSum += priceDiff;
                else
                    lossSum += Math.Abs(priceDiff);
            }

            decimal avgGain = gainSum / (prices.Count - 1);
            decimal avgLoss = lossSum / (prices.Count - 1);

            // Calculate RSI
            decimal rs = avgLoss != 0 ? avgGain / avgLoss : 0;
            decimal rsi = 100 - (100 / (1 + rs));

            return rsi;
        }


        public async Task<List<decimal>> CalculateLastRSIs(string pair, int offset, int amount)
        {
            List<decimal> values = new List<decimal>();
            DateTime date = DateTime.Now.AddDays(-1);

            var prices = await GetPreviousPrices(pair, date, offset);

            for(int k =0; k<prices.Count; k++)
                Console.Write(prices[k] + " ");
            Console.WriteLine("");

            var value = await CalculateRSI(prices);
            Console.WriteLine("value = " + value);
            values.Add(value);
            if (amount == 1)
                return values;
            else
            {
                date = date.AddDays(-offset);
                for (int i = 0; i < amount - 1; i++)
                {
                    prices.RemoveAt(0);
                    prices.Add(await GetHistoricalPrice(pair, date));

                    for (int k = 0; k < prices.Count; k++)
                        Console.Write(prices[k] + " ");
                    Console.WriteLine("");

                    value = await CalculateRSI(prices);
                    Console.WriteLine("value = " + value);
                    values.Add(value);
                    date = date.AddDays(-1);
                }

            }

            return values;

        }


    }
}

