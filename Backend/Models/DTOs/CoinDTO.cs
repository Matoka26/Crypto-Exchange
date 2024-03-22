namespace test_binance_api.Models.DTOs
{
    public class CoinDTO
    {
        public Guid? Id { get; set; }
        public string? Symbol { get; set; }
        public decimal? Amount { get; set; }

    }
}
