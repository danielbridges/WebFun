namespace LuresWebLib
{
    public interface IRepository<T> where T : class
    {
        void Save(T listToSave);
        T Load();
    }
}