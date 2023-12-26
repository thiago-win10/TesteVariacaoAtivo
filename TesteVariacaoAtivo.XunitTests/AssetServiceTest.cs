using AutoFixture;
using Moq;
using TesteVariacaoAtivo.Application.Internal.Interfaces;
using TesteVariacaoAtivo.Application.Internal.Services;
using TesteVariacaoAtivo.Domain.Entities;
using TesteVariacaoAtivo.Domain.Interfaces.Repository;

namespace TesteVariacaoAtivo.XunitTests
{
    public class AssetServiceTest
    {
        private readonly IAssetService _assetService;
        private readonly Mock<IAssetRepository> _assetRepository;

        public AssetServiceTest()
        {
            _assetRepository = new Mock<IAssetRepository>();
            _assetService = new AssetService(_assetRepository.Object);
        }

        [Fact]
        public async Task GetAssets_ReturnsExpectedAssetResponsePercentages()
        {
            var _asset = new Asset();
            var actionName = _asset.AssetName = "PETR4.SA";
            var assetRepositoryMock = new Mock<IAssetRepository>();
            var assetService = new AssetService(assetRepositoryMock.Object);

            assetRepositoryMock.Setup(repo => repo.LastThirtyTradingSessions(actionName))
                               .ReturnsAsync(GetAssets());

            var result = await assetService.GetAssets(actionName);

            Assert.NotNull(result);

        }
        public List<Asset> GetAssets()
        {
            return new Fixture().CreateMany<Asset>().ToList();
        }
    }
}