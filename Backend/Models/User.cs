using Microsoft.AspNetCore.Identity;

namespace test_binance_api.Models
{
    public class User : IdentityUser<Guid>
    {
        public string? DeviceToken { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? NickName { get; set; }
        public bool Consent { get; set; }

        public History History { get; set; }
        

    }
}
