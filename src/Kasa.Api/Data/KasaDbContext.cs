using Kasa.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Kasa.Api.Data
{
    public class KasaDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public KasaDbContext()
        {

        }
        public KasaDbContext(DbContextOptions<KasaDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("MySqlConnection");
            optionsBuilder.UseMySQL(connectionString);
        }
    }
}
