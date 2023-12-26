using TesteVariacaoAtivo.Application.Integration.Response;

namespace TesteVariacaoAtivo.Application.Integration.Interfaces
{
    public interface IFinanceYahooIntegration
    {
        Task<AssetResponse> GetDataFinanceYahoo(string startDate);

    }
}
