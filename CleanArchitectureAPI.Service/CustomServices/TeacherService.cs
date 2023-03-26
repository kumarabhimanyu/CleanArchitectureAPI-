using CleanArchitectureAPI.Domain.Models;
using CleanArchitectureAPI.Repository.IRepository;
using CleanArchitectureAPI.Service.ICustomServices;

namespace ServiceLayer.CustomServices
{
    public class TeacherService : ICustomService<Teacher>
    {
        private readonly IRepository<Teacher> _TeacherRepository;
        public TeacherService(IRepository<Teacher> TeacherRepository)
        {
            _TeacherRepository = TeacherRepository;
        }
        public void Delete(Teacher entity)
        {
            try
            {
                if(entity!=null)
                {
                    _TeacherRepository.Delete(entity);
                    _TeacherRepository.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public  Teacher Get(int Id)
        {
            try
            {
                var obj = _TeacherRepository.Get(Id);
                if(obj!=null)
                {
                    return obj;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Teacher> GetAll()
        {
            try
            {
                var obj = _TeacherRepository.GetAll();
                if (obj != null)
                {
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Insert(Teacher entity)
        {
            try
            {
                if (entity != null)
                {
                    _TeacherRepository.Insert(entity);
                    _TeacherRepository.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Remove(Teacher entity)
        {
            try
            {
                if(entity!=null)
                {
                  _TeacherRepository.Remove(entity);
                  _TeacherRepository.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Update(Teacher entity)
        {
            try
            {
                if(entity!=null)
                {
                    _TeacherRepository.Update(entity);
                    _TeacherRepository.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
