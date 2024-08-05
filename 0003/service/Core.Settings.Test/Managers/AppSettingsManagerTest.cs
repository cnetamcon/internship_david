using Core.Settings.Interfaces;
using Models;
using NUnit.Framework;

namespace Core.Settings.Test.Managers
{
    public class AppSettingsManagerTest : BaseTest
    {
        IAppSettingsManager _settings;

        [SetUp]
        public void SetUp()
        {
            _settings = GetService<IAppSettingsManager>();
        }

        [Test]
        public void Get()
        {
            var settings = _settings.Get();
            Assert.IsTrue(settings.Framerate == 25);
            Assert.IsTrue(settings.OverwriteStlFile == OverwriteStlFileEnum.NotOverwrite);
        }
    }
}
