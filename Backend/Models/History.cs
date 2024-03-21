using Microsoft.AspNetCore.Identity;

namespace test_binance_api.Models
{
    public class History
    {
        public Guid? Id { get; set; }
        public Guid? IdUser { get; set; } 
        public User? User { get; set; }
        public ICollection<Coin>? Transactions { get; set; }
    }
}
