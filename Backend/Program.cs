using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NETCore.MailKit.Core;
using test_binance_api.Data;
using test_binance_api.Helpers.Extensions;
using test_binance_api.Helpers.Seeders;
using test_binance_api.Models;
using User.Mailing.Service.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BinanceContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddIdentity<User, IdentityRole<Guid>>()
                .AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<BinanceContext>();

builder.Services.Configure<IdentityOptions>(opt =>
{
    opt.Password.RequireDigit = false;
    opt.Password.RequiredLength = 8;
    opt.User.RequireUniqueEmail = true;
    opt.SignIn.RequireConfirmedAccount = false;
    opt.SignIn.RequireConfirmedEmail = false;
    opt.SignIn.RequireConfirmedPhoneNumber = false;
});


// Add Email Configs
var emailConfig = builder.Configuration
           .GetSection("EmailConfiguration")
           .Get<EmailConfiguration>();
builder.Services.AddSingleton(emailConfig);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddSeeder();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();
SeedData(app);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
    using (var scope = scopedFactory.CreateScope())
    {
        var userService = scope.ServiceProvider.GetService<UserSeeder>();
        userService.SeedInitialUsers();

        var roleService = scope.ServiceProvider.GetService<RoleSeeder>();
        roleService.SeedInitialRoles();

        var userRoleService = scope.ServiceProvider.GetService<UserRoleSeeder>();
        userRoleService.SeedInitialUserRole();

    }
}
