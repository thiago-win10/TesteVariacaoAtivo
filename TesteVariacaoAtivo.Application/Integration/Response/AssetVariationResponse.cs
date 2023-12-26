﻿using Newtonsoft.Json;

namespace TesteVariacaoAtivo.Application.Integration.Response
{
    public partial class AssetResponse
    {
        [JsonProperty("chart")]
        public Chart Chart { get; set; }
    }

    public partial class Chart
    {
        [JsonProperty("result")]
        public Result[] Result { get; set; }

        [JsonProperty("error")]
        public object Error { get; set; }
    }

    public partial class Result
    {
        [JsonProperty("meta")]
        public Meta Meta { get; set; }

        [JsonProperty("timestamp")]
        public long[] Timestamp { get; set; }

        [JsonProperty("indicators")]
        public Indicators Indicators { get; set; }
    }

    public partial class Indicators
    {
        [JsonProperty("quote")]
        public Quote[] Quote { get; set; }
    }

    public partial class Quote
    {
        [JsonProperty("high")]
        public double?[] High { get; set; }

        [JsonProperty("volume")]
        public long?[] Volume { get; set; }

        [JsonProperty("low")]
        public double?[] Low { get; set; }

        [JsonProperty("close")]
        public decimal?[] Close { get; set; }

        [JsonProperty("open")]
        public decimal?[] Open { get; set; }
    }

    public partial class Meta
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("exchangeName")]
        public string ExchangeName { get; set; }

        [JsonProperty("instrumentType")]
        public string InstrumentType { get; set; }

        [JsonProperty("firstTradeDate")]
        public long FirstTradeDate { get; set; }

        [JsonProperty("regularMarketTime")]
        public long RegularMarketTime { get; set; }

        [JsonProperty("gmtoffset")]
        public long Gmtoffset { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("exchangeTimezoneName")]
        public string ExchangeTimezoneName { get; set; }

        [JsonProperty("regularMarketPrice")]
        public double RegularMarketPrice { get; set; }

        [JsonProperty("chartPreviousClose")]
        public double ChartPreviousClose { get; set; }

        [JsonProperty("previousClose")]
        public double PreviousClose { get; set; }

        [JsonProperty("scale")]
        public long Scale { get; set; }

        [JsonProperty("priceHint")]
        public long PriceHint { get; set; }

        [JsonProperty("currentTradingPeriod")]
        public CurrentTradingPeriod CurrentTradingPeriod { get; set; }

        [JsonProperty("tradingPeriods")]
        public Post[][] TradingPeriods { get; set; }

        [JsonProperty("dataGranularity")]
        public string DataGranularity { get; set; }

        [JsonProperty("range")]
        public string Range { get; set; }

        [JsonProperty("validRanges")]
        public string[] ValidRanges { get; set; }
    }

    public partial class CurrentTradingPeriod
    {
        [JsonProperty("pre")]
        public Post Pre { get; set; }

        [JsonProperty("regular")]
        public Post Regular { get; set; }

        [JsonProperty("post")]
        public Post Post { get; set; }
    }

    public partial class Post
    {
        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("start")]
        public long Start { get; set; }

        [JsonProperty("end")]
        public long End { get; set; }

        [JsonProperty("gmtoffset")]
        public long Gmtoffset { get; set; }
    }
}
