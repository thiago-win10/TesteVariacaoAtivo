using TesteVariacaoAtivo.Application.Internal.Response;

namespace TesteVariacaoAtivo.Application.Internal.Interfaces
{
    public interface IAssetService
    {
        Task<IEnumerable<AssetResponsePercentage>> GetAssets(string actionName);
    }
}
