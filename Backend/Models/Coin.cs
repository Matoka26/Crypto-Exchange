namespace test_binance_api.Models
{
    public class Coin
    {
        public Guid? Id { get; set; }
        public string? Symbol { get; set; }
        public decimal? Price { get; set; }
        public decimal? Amount { get; set; }
        public string? Field { get; set; }
        public DateTime? DateTime { get; set; }
        public string? Type { get; set; } //buy or sell


        public Guid? IdHistory { get; set; }
        public History? History { get; set; }

    }
}
