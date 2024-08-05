using AM;
using AM.Interfaces;
using AM.Srt;
using AM.Srt.Interfaces;
using AM.Stl;
using AM.Stl.Interfaces;
using BL.Observers;
using BL.Observers.Interfaces;
using BL.Services;
using BL.Services.Interfaces;
using Core.Converters;
using Core.Encrypts;
using Core.Interfaces.Converters;
using Core.Interfaces.DI;
using Core.Interfaces.Encrypts;
using Core.Interfaces.Mapping;
using Core.Settings;
using Core.Settings.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Host.Config
{
    public class DIRegistration
    {
        public DIRegistration()
        {
        }

        public virtual void RegisterAll(ref IServiceCollection services)
        {
            RegisterConfigs(ref services);
            RegisterServices(ref services);
            RegisterRepositories(ref services);
            RegisterManagers(ref services);
            RegisterCache(ref services);
            RegisterObservers(ref services);
            RegisterSettings(ref services);
        }

        private void RegisterObservers(ref IServiceCollection services)
        {
            services.AddSingleton<IObserversPool, ObserversPool>();
        }

        public virtual void RegisterConfigs(ref IServiceCollection services)
        {

            services.AddSingleton<Application>();
            services.AddSingleton<DIRegistration>();
            services.AddTransient<IDependencyResolver, DependencyResolver>();
            services.AddTransient<DataMapperConfig>();
            services.AddSingleton<IDataMapper, DataMapper>();
        }

        public virtual void RegisterServices(ref IServiceCollection services)
        {
            services.AddTransient<IPlaylistBuildService, PlaylistBuildService>();
            services.AddTransient<ISrtToStlService, SrtToStlService>();
        }

        public virtual void RegisterRepositories(ref IServiceCollection services)
        {
            // Repositories
        }

        public virtual void RegisterManagers(ref IServiceCollection services)
        {
            // Managers

            services.AddTransient<IEncryptManager, EncryptManager>();
            services.AddTransient<IXmlConvertManager, XmlConvertManager>();
            services.AddTransient<IJsonConvertManager, JsonConvertManager>();

            services.AddTransient<IFileManager, WindowsFileManager>();

            services.AddTransient<IStlManager, StlManager>();
            services.AddTransient<ISrtManager, SrtManager>();
            services.AddTransient<IArgumentsManager, ArgumentsManager>();
        }

        private void RegisterSettings(ref IServiceCollection services)
        {
            services.AddSingleton<IAppSettingsManager, AppSettingsManager>();
            services.AddSingleton<ISrtEncodingSettingsManager, SrtEncodingSettingsManager>();
            services.AddSingleton<ISubtitleColorSettingsManager, SubtitleColorSettingsManager>();
        }

        public virtual void RegisterCache(ref IServiceCollection services)
        {
        }
    }
}
