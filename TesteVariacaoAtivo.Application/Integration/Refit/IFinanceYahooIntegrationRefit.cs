using Refit;
using TesteVariacaoAtivo.Application.Integration.Response;

namespace TesteVariacaoAtivo.Application.Integration.Refit
{
    public interface IFinanceYahooIntegrationRefit
    {
        [Get("/finance/chart/{symbol}?interval=1d&range=1mo")]
        Task<ApiResponse<AssetResponse>> GetDataFinanceYahoo(string symbol);

    }
}
