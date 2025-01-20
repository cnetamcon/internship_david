using Core.Interfaces.Converters;
using Core.Interfaces.Encrypts;
using Core.Settings.Interfaces;
using Core.Settings.Models;
using Core.Store;
using System.Security.Cryptography.X509Certificates;

namespace Core.Settings
{
    public class SubtitleColorSettingsManager : FileStoreManager<SubtitleColorAModel>, ISubtitleColorSettingsManager
    {
        public SubtitleColorSettingsManager(IEncryptManager encryptManager,
            IJsonConvertManager convertManager)
                : base(encryptManager, convertManager, "SubtitleColorSettings.json", "Configuration")
        {
        }
    }
}
