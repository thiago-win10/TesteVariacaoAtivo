using Microsoft.EntityFrameworkCore;
using TesteVariacaoAtivo.Domain.Entities;
using TesteVariacaoAtivo.Domain.Interfaces.Repository;
using TesteVariacaoAtivo.Infra.Data;

namespace TesteVariacaoAtivo.Infra.Repository
{
    public class AssetRepository : IAssetRepository
    {
        private readonly TestAssetContext _ativoContext;
        public AssetRepository(TestAssetContext ativoContext)
        {
            _ativoContext = ativoContext;
        }

        public async Task<IEnumerable<Asset>> LastThirtyTradingSessions(string nameAction)
        {
            return await _ativoContext.Assets.Where(x => x.AssetName == nameAction).Take(30).ToListAsync();

        }
        public async Task<List<Asset>> Register(List<Asset> assetVariation)
        {
            _ativoContext.Assets.BulkInsert(assetVariation, options => { options.InsertIfNotExists = true; });
            await _ativoContext.SaveChangesAsync();

            return assetVariation;

        }
    }
}


