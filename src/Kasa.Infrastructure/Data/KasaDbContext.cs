using Kasa.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Kasa.Infrastructure.Data
{
    public class KasaDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public KasaDbContext() { }
        public KasaDbContext(DbContextOptions<KasaDbContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory().Replace("Infrastructure","Api"))
                .AddJsonFile("appsettings.json")
                .Build();
            
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));
            var connectionString = configuration.GetConnectionString("MySqlConnection");
            optionsBuilder.UseMySql(connectionString, serverVersion);
        }
    }
}
