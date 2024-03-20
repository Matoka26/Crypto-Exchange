using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using test_binance_api.Repository.CoinRepository;
using test_binance_api.Service.CoinService;

namespace test_binance_api.Helpers.Extensions
{
    public static class ServiceExtensions
    {

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ICoinRepository, CoinRepository>();
            services.AddHttpClient();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<ICoinService, CoinService>();

            return services;
        }


    }
}
