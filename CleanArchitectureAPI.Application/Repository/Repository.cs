using CleanArchitectureAPI.Repository.IRepository;
using CleanArchitectureAPI.Domain.Data;
using CleanArchitectureAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureAPI.Repository.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly CleanArchitectureAPIDBContext _cleanArchitectureAPIDBContext;
        private DbSet<T> entities;

        public Repository(CleanArchitectureAPIDBContext applicationDbContext)
        {
            _cleanArchitectureAPIDBContext = applicationDbContext;
            entities = _cleanArchitectureAPIDBContext.Set<T>();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            _cleanArchitectureAPIDBContext.SaveChanges();
        }

        public T Get(int Id)
        {
            return entities.SingleOrDefault(c => c.Id == Id);
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            _cleanArchitectureAPIDBContext.SaveChanges();
        }

        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
        }

        public void SaveChanges()
        {
            _cleanArchitectureAPIDBContext.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            _cleanArchitectureAPIDBContext.SaveChanges();
        }

    }
}
