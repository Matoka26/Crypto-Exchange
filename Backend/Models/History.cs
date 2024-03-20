namespace test_binance_api.Models
{
    public class History
    {
        public Guid Id { get; set; }
        public ICollection<Coin> Transactions { get; set; }
        public User User { get; set; }
    }
}
