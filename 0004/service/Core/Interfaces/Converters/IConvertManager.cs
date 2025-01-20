namespace Core.Interfaces.Converters
{
    public interface IConvertManager
    {
        string Serialize<T>(T model);
        T Deserialize<T>(string text);
    }
}
