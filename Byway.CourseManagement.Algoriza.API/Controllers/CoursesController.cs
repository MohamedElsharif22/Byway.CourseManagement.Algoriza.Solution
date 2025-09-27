using AutoMapper;
using Byway.Application.Contracts;
using Byway.Application.Specifications;
using Byway.CourseManagement.Algoriza.API.DTOs;
using Byway.CourseManagement.Algoriza.API.Errors;
using Byway.CourseManagement.Algoriza.API.Pagination;
using Byway.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Byway.CourseManagement.Algoriza.API.Controllers
{
    public class CoursesController(ICourseService courseService, IMapper mapper) : BaseApiController
    {
        private readonly ICourseService _courseService = courseService;
        private readonly IMapper _mapper = mapper;

        [EndpointSummary("Get All Courses")]
        [ProducesResponseType(typeof(Pagination<CourseResponse>), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        [HttpGet]
        public async Task<ActionResult<Pagination<CourseResponse>>> GetCourses([FromQuery] CourseSpecParams specParams)
        {
            var (courses,count) = await _courseService.GetAllCoursesWithCountAsync(specParams);

            var mappedCourses = courses.Select(c => _mapper.Map<CourseResponse>(c));

            return Ok(new Pagination<CourseResponse>(specParams.PageIndex, specParams.PageSize, count, mappedCourses));
        }

        [EndpointSummary("Get Course by Id")]
        [ProducesResponseType(typeof(CourseResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse),StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseResponse>> GetCourseById(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course is null)
                return NotFound(new ApiResponse(404));
            
            var mappedCourse = _mapper.Map<CourseResponse>(course);
            return Ok(mappedCourse);
        }

        [HttpGet("Categories")]
        [EndpointSummary("Get All Categories")]
        [ProducesResponseType(typeof(IEnumerable<CategoryResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<CategoryResponse>>> GetCategories()
        {
            var categories = await _courseService.GetAllCategoriesAsync();

            if (!categories.Any())
                return new ObjectResult(new ApiResponse(StatusCodes.Status204NoContent, "There are no Categories yet!"));

            return Ok(categories.Select(c => _mapper.Map<CategoryResponse>(c)));
        }

    }
}
