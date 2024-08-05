using Microsoft.Extensions.DependencyInjection;
using System;

namespace Core.Test
{
    public class BaseTest
    {
        private readonly IServiceScope _scope;
        protected DateTime _utcTimeNow = new DateTime(2022, 12, 01, 12, 00, 00, DateTimeKind.Utc);

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
