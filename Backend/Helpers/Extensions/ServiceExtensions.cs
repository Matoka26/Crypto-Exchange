using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;
using test_binance_api.Helpers.Seeders;
using test_binance_api.Models;
using test_binance_api.Repository.CoinRepository;
using test_binance_api.Repository.GenericRepository;
using test_binance_api.Repository.UserRepository;
using test_binance_api.Service.CoinService;
using test_binance_api.Service.UserService;
using test_binance_api.Service.UserWalletHistoryService;

namespace test_binance_api.Helpers.Extensions
{
    public static class ServiceExtensions
    {

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IHistoryRepository, HistoryRepository>();
            services.AddTransient<ICoinRepository, CoinRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddScoped<UserManager<User>>();
            services.AddScoped<RoleManager<IdentityRole<Guid>>>();
            services.AddHttpClient();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<ICoinService, CoinService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserWalletHistoryService, UserWalletHistoryService>();

            return services;
        }

        public static IServiceCollection AddSeeder(this IServiceCollection services)
        {
            services.AddTransient<UserSeeder>();
            services.AddTransient<RoleSeeder>();
            services.AddTransient<UserRoleSeeder>();

            return services;
        }


    }
}
