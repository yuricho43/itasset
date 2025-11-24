using Microsoft.EntityFrameworkCore;

namespace AssetManagement.ModelAsset
{
    public class AssetDbContext : DbContext
    {
        public AssetDbContext()
        {

        }

        public AssetDbContext(DbContextOptions<AssetDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Get ConnectionString from appsettings.json
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }

        public DbSet<ITAssetMain> iTAssetMains { get; set; }
        public DbSet<ColumnsInfo> columnsInfos { get; set; }
        public DbSet<ChangeHistory> changeHistories { get; set; }


    }
}
