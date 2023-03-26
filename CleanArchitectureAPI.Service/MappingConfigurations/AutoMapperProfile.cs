using AutoMapper;
using CleanArchitectureAPI.Domain.Models;
using CleanArchitectureAPI.Service.Models;

namespace CleanArchitectureAPI.Service.MappingConfigurations
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //StudentServiceModel does not have age, first name and last name property, hence we need to write logic to
            //populate the Student model
            CreateMap<StudentServiceModel, Student>()
                .ForMember(dest => dest.Age, act => act.MapFrom(src => (DateTime.Now - src.DoB).Days / 365))
                .ForMember(dest => dest.FirstName, act => act.MapFrom(src => src.FullName.Split(" ", StringSplitOptions.None)[0]))
                .ForMember(dest => dest.LastName, act => act.MapFrom(src => src.FullName.Split(" ", StringSplitOptions.None)[1]));

            //All attributes of Student already exists in StudentServiceModel, so no explicit conversion is needed
            CreateMap<Student, StudentServiceModel>();

            //Here both class has same attribute, so we can do both way mapping with using ReverseMap in 1 line of code
            CreateMap<Teacher, TeacherServiceModel>().ReverseMap();
        }
    }
}
