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

        public T Get(int Id)
        {
            return entities.SingleOrDefault(c => c.Id == Id && c.IsActive == true);
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable().Where(x=>x.IsActive == true);
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            var currentTime = DateTime.UtcNow;
            entity.CreatedDate = entity.ModifiedDate= currentTime;
            entity.IsActive = true;

            entities.Add(entity);
            _cleanArchitectureAPIDBContext.SaveChanges();
        }                  

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entity.ModifiedDate = DateTime.UtcNow;
            entities.Update(entity);
            _cleanArchitectureAPIDBContext.SaveChanges();
        }

        public void Delete(int Id)
        {
            var entity = entities.SingleOrDefault(c => c.Id == Id);

            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            _cleanArchitectureAPIDBContext.SaveChanges();
        }

        public void Remove(int Id)
        {
            var entity = entities.SingleOrDefault(c => c.Id == Id);

            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entity.IsActive = false;
            entities.Update(entity);
            _cleanArchitectureAPIDBContext.SaveChanges();
        }
        public void SaveChanges()
        {
            _cleanArchitectureAPIDBContext.SaveChanges();
        }
    }
}
