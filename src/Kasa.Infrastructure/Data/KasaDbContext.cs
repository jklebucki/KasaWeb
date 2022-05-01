using Kasa.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Kasa.Infrastructure.Data
{
    public class KasaDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyGroup> CompanyGroups { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<CashPoint> CashPoints { get; set; }
        public DbSet<CashOperation> CashOperations { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentItem> DocumentItems { get; set; }
        public KasaDbContext() { }
        public KasaDbContext(DbContextOptions<KasaDbContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory().Replace("Infrastructure", "Api"))
                .AddJsonFile("appsettings.json")
                .Build();

            var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));
            var connectionString = configuration.GetConnectionString("MySqlConnection");
            optionsBuilder.UseMySql(connectionString, serverVersion);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(b => b.Email)
                .IsUnique(true);
        }
    }
}
