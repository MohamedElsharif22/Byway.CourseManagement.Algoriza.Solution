using AutoMapper;
using Byway.CourseManagement.Algoriza.API.DTOs;
using Byway.Domain.Entities;

namespace Byway.CourseManagement.Algoriza.API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Course, CourseResponse>()
                .ForMember(dest => dest.InstructorName, opt => opt.MapFrom(src => src.Instructor != null ? src.Instructor.Name : "No Instructor"))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<CourseRequest, Course>()
                .ForMember(c => c.CoverPictureUrl, opt => opt.Ignore());

            CreateMap<Category, CategoryResponse>();
        }
    }
}
