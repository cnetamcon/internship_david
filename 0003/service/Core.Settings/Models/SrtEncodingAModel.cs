using Core.Converters.NewtonsoftConverters;
using Models.Store;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Core.Settings.Models
{
    public class SrtEncodingAModel : StoreAModel
    {
        [JsonProperty("pairs")] public List<SrtEncodingPairAModel> Pairs { get; set; }
    }

    public class SrtEncodingPairAModel
    {
        [JsonConverter(typeof(StringByteArrayConverter))]
        [JsonProperty("from")] public byte[] From { get; set; }

        [JsonConverter(typeof(StringByteArrayConverter))]
        [JsonProperty("to")] public byte[] To { get; set; }
    }
}
