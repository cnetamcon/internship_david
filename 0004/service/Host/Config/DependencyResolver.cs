using Core.Interfaces.DI;
using Core.Logs;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Host.Config
{
    public class DependencyResolver : IDependencyResolver, IDisposable
    {
        IServiceProvider _serviceProvider;
        IServiceScope _scope;

        public DependencyResolver(IServiceProvider provider)
        {
            _serviceProvider = provider;
            _scope = _serviceProvider.CreateScope();
        }
        ~DependencyResolver()
        {
            Log.Current.Debug("Wait out");
        }
        public void Dispose()
        {
            Log.Current.Warning($"Dispose service scope");
            _scope?.Dispose();
            _scope = null;
        }

        public T Resolve<T>()
        {
            T result = default;
            try
            {
                result = _scope.ServiceProvider.GetRequiredService<T>();
            }
            catch (Exception er)
            {
                Log.Current.Error(er);
                throw er;
            }
            return result;
        }

        public IServiceScope CreateScope()
        {
            return _serviceProvider.CreateScope();
        }
    }
}