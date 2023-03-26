using CleanArchitectureAPI.Domain.Models;

namespace CleanArchitectureAPI.Repository.IRepository
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T Get(int Id);
        void Insert(T entity);
        
        //ToDo - How to update specific columns during update
        void Update(T entity);

        //Hard Delete
        void Delete(int Id);
        
        //Soft Delete
        void Remove(int Id);
        void SaveChanges();
    }
}
