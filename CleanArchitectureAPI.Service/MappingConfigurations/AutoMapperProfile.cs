using AutoMapper;
using CleanArchitectureAPI.Domain.Models;
using CleanArchitectureAPI.Service.Models;

namespace CleanArchitectureAPI.Service.MappingConfigurations
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Student, StudentServiceModel>().ReverseMap(); ;
            CreateMap<Teacher, TeacherServiceModel>().ReverseMap();
        }
    }
}
