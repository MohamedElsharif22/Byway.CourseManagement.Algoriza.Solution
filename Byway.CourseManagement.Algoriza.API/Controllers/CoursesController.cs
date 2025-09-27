using AutoMapper;
using Byway.Application.Contracts;
using Byway.Application.File_Service;
using Byway.Application.Specifications;
using Byway.CourseManagement.Algoriza.API.DTOs;
using Byway.CourseManagement.Algoriza.API.Errors;
using Byway.CourseManagement.Algoriza.API.Extensions;
using Byway.CourseManagement.Algoriza.API.Pagination;
using Byway.Domain;
using Byway.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Byway.CourseManagement.Algoriza.API.Controllers
{
    public class CoursesController(ICourseService courseService, 
                                   IMapper mapper,
                                   IFileUploadService fileUploadService) : BaseApiController
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

        [HttpPost]
        public async Task<ActionResult> CreateCourse([FromForm] CourseRequest courseRequest)
        {
            
            var course = _mapper.Map<Course>(courseRequest);
            var result = await _courseService.CreateCourseAsync(course, courseRequest.CoverPicture);

            if (result == 0)
                return BadRequest(new ApiResponse(400, "Failed to create the course"));

            return StatusCode(201, new ApiResponse(201, "Course created successfully"));
            
        }

        [HttpPut("{id}")]
        [EndpointSummary("Update Course")]
        public async Task<ActionResult> UpdateCourse(int id, [FromForm] CourseRequest courseRequest)
        {
            var result = await _courseService.UpdateCourseAsync(id, courseRequest.ToCourseEntity(), courseRequest.CoverPicture);

            if (result == 0)
                return BadRequest(new ApiResponse(StatusCodes.Status400BadRequest, "Course Cannot be Ubdated"));

            return Ok(new ApiResponse(200, "Course updated successfully"));
        }


        [HttpDelete("{id}")]
        [EndpointSummary("Delete Course")]
        public async Task<ActionResult> DeleteCourse(int id)
        {
            var result = await _courseService.DeleteCourseAsync(id);
            if (result == 0)
                return BadRequest(new ApiResponse(StatusCodes.Status400BadRequest, "Course Cannot be Deleted"));
            return Ok(new ApiResponse(200, "Course deleted successfully"));
        }


    }
}
