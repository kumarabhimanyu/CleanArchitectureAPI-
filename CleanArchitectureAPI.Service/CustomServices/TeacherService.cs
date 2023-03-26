using AutoMapper;
using CleanArchitectureAPI.Domain.Models;
using CleanArchitectureAPI.Repository.IRepository;
using CleanArchitectureAPI.Service.ICustomServices;
using CleanArchitectureAPI.Service.Models;

namespace ServiceLayer.CustomServices
{
    public class TeacherService : ICustomService<TeacherServiceModel>
    {
        private readonly IRepository<Teacher> _teacherRepository;
        private readonly IMapper _mapper;
        public TeacherService(IRepository<Teacher> TeacherRepository, IMapper mapper)
        {
            _teacherRepository = TeacherRepository;
            _mapper = mapper;
        }
        public TeacherServiceModel Get(int Id)
        {
            var obj = _teacherRepository.Get(Id);
            if (obj != null)
            {
                return _mapper.Map<TeacherServiceModel>(obj);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<TeacherServiceModel> GetAll()
        {
            var obj = _teacherRepository.GetAll();
            if (obj != null)
            {
                return _mapper.Map<List<TeacherServiceModel>>(obj);
            }
            else
            {
                return null;
            }
        }

        public void Insert(TeacherServiceModel entity)
        {
            if (entity != null)
            {
                _teacherRepository.Insert(_mapper.Map<Teacher>(entity));
                _teacherRepository.SaveChanges();
            }
        }

        public void Update(TeacherServiceModel entity)
        {
            if (entity != null)
            {
                _teacherRepository.Update(_mapper.Map<Teacher>(entity));
                _teacherRepository.SaveChanges();
            }
        }

        public void Delete(int Id)
        {
            _teacherRepository.Delete(Id);
            _teacherRepository.SaveChanges();
        }
        public void Remove(int Id)
        {
            _teacherRepository.Remove(Id);
            _teacherRepository.SaveChanges();
        }
    }
}
