using Host.Config;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Settings.Test
{
    public class TestEnv
    {
        private readonly static TestEnv _instanse = new TestEnv();
        public static TestEnv Current => _instanse;
        private ServiceProvider _serviceProvider;

        TestEnv()
        {
            Initialize();
        }

        private void Initialize()
        {
            InitializeDI();
        }

        private void InitializeDI()
        {
            IServiceCollection services = new ServiceCollection();
            DIRegistration di = new DIRegistration();
            di.RegisterAll(ref services);
            _serviceProvider = services.BuildServiceProvider();
        }

        public IServiceScope CreateScope()
        {
            return _serviceProvider.CreateScope();
        }
    }
}
