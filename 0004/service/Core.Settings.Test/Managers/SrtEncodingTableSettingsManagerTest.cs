using Core.Extensions;
using Core.Settings.Interfaces;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Core.Settings.Test.Managers
{
    public class SrtEncodingTableSettingsManagerTest : BaseTest
    {
        private ISrtEncodingSettingsManager _settings;

        [SetUp]
        public void SetUp()
        {
            _settings = GetService<ISrtEncodingSettingsManager>();
        }

        [Test]
        public void Get()
        {
            var pairs = new Dictionary<string, string>()
            {
                {"0xC3A9","0xC265"},
                {"0xC3AF","0xC869"},
                {"0xC3A0","0xC161"},
                {"0xC3AA","0xC365"},
                {"0xC3AB","0xC865"},
                {"0xC3AE","0xC369"},
                {"0xC3B9","0xC175"},
                {"0x5f","0x23"},
                {"0xC3A8","0xC165"},
                {"0xC3A2","0xC361"},
                {"0xC3B4","0xC36F"},
                {"0xC3BB", "0xC375"},
                {"0xC3A7","0xCB63"}
            };

            var settings = _settings.Get();

            Assert.IsNotNull(settings.Pairs);
            Assert.IsTrue(settings.Pairs.Count == 13, $"SRT pairs doesn't match. Excepted 13 instead of {settings.Pairs.Count}");


            foreach (var pair in pairs)
            {
                var temp = settings.Pairs.FirstOrDefault(x => x.From.CompareArray(pair.Key.ToByteArray()));

                Assert.IsNotNull(temp, $"SRT pair ${pair.Key} was not found in the settings");
                Assert.IsTrue(temp.To.CompareArray(pair.Value.ToByteArray()), $"The SRT pair doesn't match. In the settings '{temp.To}' Expected: {pair.Value} ");
            }
        }
    }
}