using AutoMapper;
using WebApiTest6._0.Application.Features.Student.Commands;
using WebApiTest6._0.Domain.Entities;

namespace WebApiTest6._0.Application.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateStudentCommand.Request, Student>();
            CreateMap<UpdateStudentCommand.Request, Student>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.StudentId));
        }
    }
}
