using Microsoft.EntityFrameworkCore;
using TesteVariacaoAtivo.Domain.Entities;
using TesteVariacaoAtivo.Infra.Configuration;

namespace TesteVariacaoAtivo.Infra.Data
{
    public class TestAssetContext : DbContext
    {
        public TestAssetContext(DbContextOptions<TestAssetContext> options)
            : base(options) { }

        public DbSet<Asset> Assets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AssetConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
