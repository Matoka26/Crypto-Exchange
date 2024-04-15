using Newtonsoft.Json.Linq;
using System;
using System.Text.Json;
using test_binance_api.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
    }
}
