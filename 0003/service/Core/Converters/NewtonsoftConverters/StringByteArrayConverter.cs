using Core.Extensions;
using Newtonsoft.Json;
using System;

namespace Core.Converters.NewtonsoftConverters
{
    public class StringByteArrayConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var str = reader.Value as string;
            var result = str.TrimStart('[')
                .TrimEnd(']')
                .Trim()
                .ToByteArray();

            return result;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
