using Core.Settings.Interfaces;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Core.Settings.Test.Managers
{
    public class SubtitleColorSettingsManagerTest : BaseTest
    {
        private ISubtitleColorSettingsManager _settings;


        [Test]
        public void Get()
        {
            _settings = GetService<ISubtitleColorSettingsManager>();

            var colors = new Dictionary<byte, string>()
            {
                {0x01,"red" },
                {0x02,"green" },
                {0x04,"blue" },
                {0x07,"white" },
                {0x00,"black" },
                {0x03,"yellow" },
                {0x05,"magenta" },
                {0x06,"cyan" },
            };

            var settings = _settings.Get();

            Assert.IsNotNull(settings.Pairs);
            Assert.IsTrue(settings.Pairs.Count == 8, $"Color pairs doesn't match. Excepted 8 instead of {settings.Pairs.Count}");

            foreach (var pair in colors)
            {
                var temp = settings.Pairs.FirstOrDefault(x => x.ColorStl == pair.Key);

                Assert.IsNotNull(temp, $"STL color ${pair.Key.ToString("X2")} was not found in the settings");
                Assert.IsTrue(temp.ColorSrt == pair.Value, $"The color doesn't match. In the settings '{temp.ColorSrt}' Expected: {pair.Value} ");
            }
        }
    }
}