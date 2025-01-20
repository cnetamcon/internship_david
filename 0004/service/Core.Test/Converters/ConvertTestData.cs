using Newtonsoft.Json;
using System;
using System.IO;

namespace Core.Test.Converters
{
    public class ConvertTestModel
    {
        [JsonIgnore] private string _json;
        [JsonIgnore] private string _xml;

        [JsonProperty("dt")] public DateTime DT { get; set; }
        [JsonProperty("time")] public TimeSpan Time { get; set; }
        [JsonProperty("int_value")] public int IntValue { get; set; }
        [JsonProperty("bool_value")] public bool BoolValue { get; set; }
        [JsonProperty("title")] public string Title { get; set; }
        [JsonProperty("path")] public string Path { get; set; }
        [JsonProperty("state")] public TestModelStateEnum State { get; set; }

        public string GetBaseJson()
        {
            if (!string.IsNullOrEmpty(_json)) return _json;

            var path = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Converters", "ConvertTestData.json");
            _json = File.ReadAllText(path);
            return _json;
        }

        public string GetBaseXml()
        {
            if (!string.IsNullOrEmpty(_xml)) return _xml;

            var path = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Converters", "ConvertTestData.xml");
            _xml = File.ReadAllText(path);
            return _xml;
        }
        public ConvertTestModel GetBaseModel()
        {
            return new ConvertTestModel()
            {
                DT = new DateTime(1997, 5, 22, 15, 45, 22, 586, DateTimeKind.Utc),
                Time = new TimeSpan(0, 18, 33, 13, 784),
                Title = "test title",
                BoolValue = true,
                IntValue = 2_147_000_000,
                Path = "C:\\test\\dir\\t.bin",
                State = TestModelStateEnum.state2
            };
        }

        public enum TestModelStateEnum
        {
            state0 = 0,
            state1 = 1,
            state2 = 2,
            state3 = 3,
        }
    }
}
