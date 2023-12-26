using TesteVariacaoAtivo.Domain.Entities;

namespace TesteVariacaoAtivo.Domain.Interfaces.Repository
{
    public interface IAssetRepository
    {
        Task<IEnumerable<Asset>> LastThirtyTradingSessions(string nameAction);
        Task<List<Asset>> Register(List<Asset> asset);

    }
}

