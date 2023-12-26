using TesteVariacaoAtivo.Application.Internal.Interfaces;
using TesteVariacaoAtivo.Application.Internal.Response;
using TesteVariacaoAtivo.Domain.Entities;
using TesteVariacaoAtivo.Domain.Interfaces.Repository;

namespace TesteVariacaoAtivo.Application.Internal.Services
{
    public class AssetService : IAssetService
    {
        private readonly IAssetRepository _assetRepository;
        public AssetService(IAssetRepository assetRepository)
        {
            _assetRepository = assetRepository;
        }
        public async Task<IEnumerable<AssetResponsePercentage>> GetAssets(string actionName)
        {
            var datasAssests = await _assetRepository.LastThirtyTradingSessions(actionName);

            var assetsPercentage = await GetPercentagesAssets(datasAssests.ToList());

            return assetsPercentage;
        }
        private async Task<List<AssetResponsePercentage>> GetPercentagesAssets(List<Asset> stocks)
        {
            List<AssetResponsePercentage> result = new List<AssetResponsePercentage>();

            if (stocks != null && stocks.Count > 0)
            {
                var firstPrice = stocks[0].Price;
                var previousPrice = firstPrice;


                foreach (var stock in stocks)
                {
                    AssetResponsePercentage assetResponse = new AssetResponsePercentage();
                    assetResponse.AssetName = stock.AssetName;
                    assetResponse.Price = stock.Price;

                    assetResponse.VariationRelationFirstDay = Convert.ToString(CalculatePercentageChange(firstPrice, stock.Price)) + " %";
                    assetResponse.VariationRelationPreviousDay = Convert.ToString(CalculatePercentageChange(previousPrice, stock.Price)) + " %";

                    previousPrice = stock.Price;
                    result.Add(assetResponse);
                }
            }

            return result;

        }
        private static string CalculatePercentageChange(decimal? initial, decimal? final)
        {
            if (initial == 0) return 0.ToString();
            return (((final.Value - initial.Value) / initial.Value) * 100).ToString("F2");
        }

    }
}