using AM.Models;

namespace AM.Interfaces
{
    public interface IArgumentsManager
    {
        ArgumentsModel Parse(string[] args);
    }
}
