using TesteVariacaoAtivo.Application.Integration.Interfaces;
using TesteVariacaoAtivo.Application.Integration.Refit;
using TesteVariacaoAtivo.Application.Integration.Response;
using TesteVariacaoAtivo.Domain.Entities;
using TesteVariacaoAtivo.Domain.Interfaces.Repository;

namespace TesteVariacaoAtivo.Application.Integration.Services
{
    public class FinanceYahooIntegrationService : IFinanceYahooIntegration
    {
        private readonly IFinanceYahooIntegrationRefit _yahooIntegrationRefit;
        private readonly IAssetRepository _assetRepository;
        public FinanceYahooIntegrationService(IFinanceYahooIntegrationRefit yahooIntegrationRefit,
                                       IAssetRepository assetRepository)
        {
            _yahooIntegrationRefit = yahooIntegrationRefit;
            _assetRepository = assetRepository;
        }

        public async Task<AssetResponse> GetDataFinanceYahoo(string symbol)
        {

            try
            {
                var apiResponse = await _yahooIntegrationRefit.GetDataFinanceYahoo(symbol);

                if (apiResponse != null && apiResponse.IsSuccessStatusCode)
                {
                    var response = apiResponse.Content;
                    Asset asset = new Asset();
                    int i = 0;

                    foreach (var assetResponse in response.Chart.Result)
                    {
                        Asset[] assetList = new Asset[assetResponse.Timestamp.Count()];

                        foreach (var timestamp in assetResponse.Timestamp)
                        {
                            Asset assetObject = new Asset();

                            assetObject.AssetName = symbol;
                            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                            var formattedDate = origin.AddSeconds(timestamp);
                            assetList[i] = assetObject;
                            assetList[i].DataAsset = formattedDate;
                            i++;

                        }

                        foreach (var obj in assetList)
                        {
                            int x = 0;

                            foreach (var open in assetResponse.Indicators.Quote)
                            {
                                foreach (var openValue in open.Open)
                                {
                                    asset.Price = openValue;

                                    assetList[x].Price = openValue;
                                    x++;

                                }
                            }
                        }
                        await _assetRepository.Register(assetList.ToList());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }
    }
}
