using Models;
using Models.Store;
using Newtonsoft.Json;

namespace Core.Settings.Models
{
    public class AppSettingsAModel : StoreAModel
    {
        [JsonProperty("framerate")] public double Framerate { get; set; }
        [JsonProperty("overwrite_stl_file")] public OverwriteStlFileEnum OverwriteStlFile { get; set; }
    }
}
