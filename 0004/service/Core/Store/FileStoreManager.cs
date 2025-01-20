using Core.Interfaces.Converters;
using Core.Interfaces.Encrypts;
using Core.Interfaces.Store;
using Models.Store;
using System;
using System.IO;

namespace Core.Store
{
    public abstract class FileStoreManager<T> : IStoreManager<T>
        where T : StoreAModel
    {
        protected string _sold = "H4uoPl8Kj12b478I";
        protected string _key = "jsf8e#!82*7lf8e*ty2!";

        protected IConvertManager _convertManager;
        protected IEncryptManager _encryptManager;
        protected DateTime? _lastChange;
        protected T _settings;
        protected object _loadFileLocker = new object();
        protected string _filename;
        protected readonly string _path;

        public FileStoreManager(IEncryptManager encryptManager, IConvertManager convertManager, string filename, string storeDir = "Store")
        {
            _filename = filename;
            _convertManager = convertManager;
            _encryptManager = encryptManager;
            var root = AppDomain.CurrentDomain.RelativeSearchPath ?? AppDomain.CurrentDomain.BaseDirectory;

            _path = Path.Combine(root, "App_Data", storeDir, filename);
        }

        public virtual void Save(T model)
        {
            lock (_loadFileLocker)
            {
                File.WriteAllText(_path, _convertManager.Serialize(model));
                _settings = Get();
            }
        }

        public virtual T Get()
        {
            lock (_loadFileLocker)
            {
                if (_settings != null && CheckSettingChanges(_path) == false)
                {
                    //Log.Current.Debug($"Settings of {_filename} already loaded");
                    return _settings;
                }
                else
                {
                    var json = File.ReadAllText(_path);

                    _settings = _convertManager.Deserialize<T>(json);//?.Replace("\\", "\\\\"));
                }
                 _settings.Initialize();

                return _settings;
            }
        }

        protected bool CheckSettingChanges(string path)
        {
            if (!File.Exists(path))
            {
                throw new ArgumentException($"Configuration '{path}' not found");
            }

            var time = File.GetLastWriteTimeUtc(path);

            if (_lastChange != time)
            {
                _lastChange = time;
                return true;
            }

            return false;
        }

        protected virtual string EncryptPassword(string pass)
        {
            if (string.IsNullOrEmpty(pass)) return "";
            if (pass.StartsWith(_sold) && pass.Length != _sold.Length) return pass;

            var result = _sold + _encryptManager.Encrypt(pass, _key);

            //Log.Current.Debug($"Encrypt password: {pass}:[{result}]");
            return result;
        }

        protected virtual string DecryptPassword(string pass)
        {
            if (string.IsNullOrEmpty(pass)) return "";
            if (pass.StartsWith(_sold) && pass.Length != _sold.Length)
            {
                var text = pass.Substring(_sold.Length, pass.Length - _sold.Length);
                var result = _encryptManager.Decrypt(text, _key);

                //Log.Current.Debug($"Encrypt password: {pass}:[{result}]");

                return result;
            }
            else
            {
                return pass;
            }
        }
    }
}
