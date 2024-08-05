using Microsoft.Extensions.DependencyInjection;
using System;

namespace Core.Interfaces.DI
{
    public interface IDependencyResolver : IDisposable
    {
        T Resolve<T>();
        IServiceScope CreateScope();
    }
}
