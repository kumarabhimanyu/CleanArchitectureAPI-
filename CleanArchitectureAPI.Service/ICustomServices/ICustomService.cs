namespace CleanArchitectureAPI.Service.ICustomServices
{
    public interface ICustomService<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int Id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int Id);
        void Remove(int Id);
    }
}
