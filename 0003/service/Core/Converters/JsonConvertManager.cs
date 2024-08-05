using Core.Interfaces.Converters;
using Newtonsoft.Json;

namespace Core.Converters
{
    public class JsonConvertManager : IJsonConvertManager
    {
        readonly JsonSerializerSettings _settings;

        public JsonConvertManager()
        {
            _settings = new JsonSerializerSettings()
            {
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                DateFormatString = "yyy-MM-ddTHH:mm:ss.fffZ"
            };
        }

        public T Deserialize<T>(string text)
        {
            var model = JsonConvert.DeserializeObject<T>(text, _settings);
            return model;
        }

        public string Serialize<T>(T model)
        {
            var json = JsonConvert.SerializeObject(model, Formatting.Indented, _settings);
            return json;
        }
    }
}
