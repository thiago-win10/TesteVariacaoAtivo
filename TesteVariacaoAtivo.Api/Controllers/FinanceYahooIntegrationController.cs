using Microsoft.AspNetCore.Mvc;
using TesteVariacaoAtivo.Application.Integration.Interfaces;
using TesteVariacaoAtivo.Application.Integration.Response;

namespace TesteVariacaoAtivo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinanceYahooIntegrationController : ControllerBase
    {
        private readonly IFinanceYahooIntegration _financeYahooIntegration;
        public FinanceYahooIntegrationController(IFinanceYahooIntegration financeYahooIntegration)
        {
            _financeYahooIntegration = financeYahooIntegration;
        }

        [HttpGet("{symbol}")]
        public async Task<ActionResult<AssetResponse>> Get(string symbol)
        {
            var response = await _financeYahooIntegration.GetDataFinanceYahoo(symbol);

            if (response == null)
            {
                return BadRequest("Dados não encontrado");
            }

            return Ok(response);
        }
    }
}
