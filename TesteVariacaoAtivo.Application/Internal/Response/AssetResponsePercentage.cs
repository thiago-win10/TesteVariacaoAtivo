namespace TesteVariacaoAtivo.Application.Internal.Response
{
    public class AssetResponsePercentage
    {
        public string? AssetName { get; set; }
        public decimal? Price { get; set; }
        public string? VariationRelationFirstDay { get; set; }
        public string? VariationRelationPreviousDay { get; set; }
    }
}
