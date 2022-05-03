using Kasa.Core.Repositories;
using Kasa.Infrastructure.AutoMapper;
using Kasa.Infrastructure.Data;
using Kasa.Infrastructure.Repositories;
using Kasa.Infrastructure.Security;
using Kasa.Infrastructure.Services;
using Kasa.Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
var connectionString = configuration.GetConnectionString("MySqlConnection");
builder.Services.AddDbContext<KasaDbContext>(options => options.UseNpgsql(connectionString));
// services & repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<ICompanyGroupRepository, CompanyGroupRepository>();
builder.Services.AddScoped<ICompanyGroupService, CompanyGroupService>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<IBankAccountRepository, BankAccountRepository>();
builder.Services.AddScoped<IBankAccountService, BankAccountService>();
//security
builder.Services.AddScoped<ISecurityProvider, SecurityProviderBase>();
builder.Services.AddSingleton(AutoMapperConfig.InitAutoMapper());
// var jwtConfig = new JwtSettings();
// var x = configuration.GetSection("jwt");//.Get(typeof(JwtSettings));// .Bind(jwtConfig);
builder.Services.Configure<JwtSettings>(configuration.GetSection("jwt"));
builder.Services.AddSingleton<IJwtHandler, JwtHandler>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
