using System.Collections.Generic;

namespace Core.Interfaces.Mapping
{
    public interface IDataMapper
    {
        To Parse<From, To>(From model);

        IEnumerable<To> Parse<From, To>(IEnumerable<From> models);
    }
}
