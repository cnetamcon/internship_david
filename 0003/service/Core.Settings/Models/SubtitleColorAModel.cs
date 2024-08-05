using Core.Converters.NewtonsoftConverters;
using Models.Store;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Core.Settings.Models
{
    public class SubtitleColorAModel : StoreAModel
    {
        [JsonProperty("pairs")] public List<SubtitleColorPairAModel> Pairs { get; set; }
    }

    public class SubtitleColorPairAModel
    {
        [JsonConverter(typeof(StringByteConverter))]
        [JsonProperty("color_stl")] public byte ColorStl { get; set; }
        [JsonProperty("color_srt")] public string ColorSrt { get; set; }
    }
}