namespace test_binance_api.Models
{
    public class Coin
    {
        public string Symbol { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; }
        public string Field { get; set; }
        public DateTime DateTime { get; set; }

    }
}
