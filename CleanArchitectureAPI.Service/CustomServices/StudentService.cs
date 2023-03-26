using AutoMapper;
using CleanArchitectureAPI.Domain.Models;
using CleanArchitectureAPI.Repository.IRepository;
using CleanArchitectureAPI.Service.ICustomServices;
using CleanArchitectureAPI.Service.Models;

namespace ServiceLayer.CustomServices
{
    public class StudentService : ICustomService<StudentServiceModel>
    {
        private readonly IRepository<Student> _studentRepository;
        private readonly IMapper _mapper;
        public StudentService(IRepository<Student> studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public StudentServiceModel Get(int Id)
        {
            var obj = _studentRepository.Get(Id);
            if (obj != null)
            {
                return _mapper.Map<StudentServiceModel>(obj);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<StudentServiceModel> GetAll()
        {
            var obj = _studentRepository.GetAll();
            if (obj != null)
            {
                return _mapper.Map<List<StudentServiceModel>>(obj);
            }
            else
            {
                return null;
            }
        }

        public void Insert(StudentServiceModel entity)
        {
            if (entity != null)
            {
                _studentRepository.Insert(_mapper.Map<Student>(entity));
                _studentRepository.SaveChanges();
            }
        }
        public void Update(StudentServiceModel entity)
        {
            if (entity != null)
            {
                _studentRepository.Update(_mapper.Map<Student>(entity));
                _studentRepository.SaveChanges();
            }
        }

        public void Delete(int Id)
        {
            _studentRepository.Delete(Id);
            _studentRepository.SaveChanges();
        }
        public void Remove(int Id)
        {
            _studentRepository.Remove(Id);
            _studentRepository.SaveChanges();
        }
    }
}
