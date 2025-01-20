using Core.Interfaces.Converters;
using Core.Interfaces.Encrypts;
using Core.Settings.Interfaces;
using Core.Settings.Models;
using Core.Store;

namespace Core.Settings
{
    public class SrtEncodingSettingsManager : FileStoreManager<SrtEncodingAModel>, ISrtEncodingSettingsManager
    {
        public SrtEncodingSettingsManager(IEncryptManager encryptManager,
            IJsonConvertManager convertManager)
                : base(encryptManager, convertManager, "SrtEncodingSettings.json", "Configuration")
        {
        }
    }
}
