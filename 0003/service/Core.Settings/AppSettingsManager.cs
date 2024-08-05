using Core.Interfaces.Converters;
using Core.Interfaces.Encrypts;
using Core.Settings.Interfaces;
using Core.Settings.Models;
using Core.Store;

namespace Core.Settings
{
    public class AppSettingsManager : FileStoreManager<AppSettingsAModel>, IAppSettingsManager
    {
        public AppSettingsManager(IEncryptManager encryptManager,
            IJsonConvertManager convertManager)
            : base(encryptManager, convertManager, "ApplicationSettings.json", "Configuration")
        {
        }
    }
}
