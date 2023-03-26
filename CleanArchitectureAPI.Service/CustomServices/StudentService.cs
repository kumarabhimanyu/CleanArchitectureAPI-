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
        public void Delete(StudentServiceModel entity)
        {
            if (entity != null)
            {
                _studentRepository.Delete(_mapper.Map<Student>(entity));
                _studentRepository.SaveChanges();
            }
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

        public void Remove(StudentServiceModel entity)
        {
            if (entity != null)
            {
                _studentRepository.Remove(_mapper.Map<Student>(entity));
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
    }
}
