namespace Core.Interfaces.Store
{
    public interface IStoreManager<T>
    {
        void Save(T model);
        T Get();
    }
}
