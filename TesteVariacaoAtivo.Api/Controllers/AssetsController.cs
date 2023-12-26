using Microsoft.AspNetCore.Mvc;
using TesteVariacaoAtivo.Application.Internal.Interfaces;
using TesteVariacaoAtivo.Application.Internal.Response;

namespace TesteVariacaoAtivo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetsController : ControllerBase
    {
        private readonly IAssetService _assetService;
        public AssetsController(IAssetService assetService)
        {
            _assetService = assetService;
        }

        [HttpGet("Assets")]
        public async Task<ActionResult<IEnumerable<AssetResponsePercentage>>> Get([FromQuery] string actionName)
        {
            var listAssets = await _assetService.GetAssets(actionName);

            return Ok(listAssets);
        }
    }
}
