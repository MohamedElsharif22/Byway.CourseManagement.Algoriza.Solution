using AutoMapper;
using Byway.Application.DTOs.Category;
using Byway.Application.DTOs.Course;
using Byway.Application.DTOs.Instructor;
using Byway.Application.Mapping.Mapping_Resolvers;
using Byway.Domain.Entities;
using Byway.Domain.Entities.Course_;
using Byway.Domain.Entities.enums;

namespace Byway.Application.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Course, CourseResponse>()
                .ForMember(dest => dest.InstructorName, opt => opt.MapFrom(src => src.Instructor != null ? src.Instructor.Name : "No Instructor"))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.CoverPictureUrl, opt => opt.MapFrom<CoursePictureUrlResolver>());

            CreateMap<CourseContent, CourseContentResponse>();

            CreateMap<CourseRequest, Course>()
                .ForMember(dest => dest.CoverPictureUrl, opt => opt.Ignore())
                .ForMember(dest => dest.Contents, opt => opt.Ignore())
                .ForMember(dest => dest.Level, opt => opt.MapFrom(c => (JobTitles) c.CousrseLevel));

            CreateMap<CourseContentRequest, CourseContent>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(c => c.contentId));

            CreateMap<Category, CategoryResponse>();

            CreateMap<InstructorRequest, Instructor>()
                .ForMember(dest => dest.ProfilePictureUrl, opt => opt.Ignore())
                .ForMember(dest => dest.JopTitle, opt => opt.MapFrom(c => (JobTitles) c.JopTitle));

        }
    }
}
