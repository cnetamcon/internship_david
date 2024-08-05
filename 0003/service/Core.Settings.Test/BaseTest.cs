using Microsoft.Extensions.DependencyInjection;

namespace Core.Settings.Test
{
    public class BaseTest
    {
        IServiceScope _scope;

        public BaseTest()
        {
            _scope = TestEnv.Current.CreateScope();
        }

        ~BaseTest()
        {
            _scope.Dispose();
        }

        protected T GetService<T>()
        {
            return _scope.ServiceProvider.GetRequiredService<T>();
        }
    }
}
