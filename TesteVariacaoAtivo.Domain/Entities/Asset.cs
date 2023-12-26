namespace TesteVariacaoAtivo.Domain.Entities
{
    public class Asset
    {
        public Guid Id { get; set; }
        public string? AssetName { get; set; }
        public DateTime DataAsset { get; set; }
        public decimal? Price { get; set; }

    }
}

