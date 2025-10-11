using AutoMapper;
using Byway.Application.Contracts;
using Byway.Application.DTOs;
using Byway.Application.DTOs.Category;
using Byway.Application.DTOs.Course;
using Byway.Application.Specifications.Course_Specs;
using Byway.CourseManagement.Algoriza.API.Errors;
using Byway.CourseManagement.Algoriza.API.Extensions;
using Byway.Domain;
using Byway.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Byway.CourseManagement.Algoriza.API.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CoursesController(ICourseService courseService, 
                                   IMapper mapper) : BaseApiController
    {
        private readonly ICourseService _courseService = courseService;
        private readonly IMapper _mapper = mapper;

        [AllowAnonymous]
        [EndpointSummary("Get All Courses")]
        [ProducesResponseType(typeof(Pagination<CourseResponse>), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        [HttpGet]
        public async Task<ActionResult<Pagination<CourseResponse>>> GetCourses([FromQuery] CourseSpecParams specParams)
        {
            var page = await _courseService.GetAllCoursesWithCountAsync(specParams);

            return Ok(page);
        }

        [AllowAnonymous]
        [EndpointSummary("Get Course by Id")]
        [ProducesResponseType(typeof(CourseResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse),StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseResponse>> GetCourseById(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course is null)
                return NotFound(new ApiResponse(404));
            
            return Ok(course);
        }

        [AllowAnonymous]
        [HttpGet("Categories")]
        [EndpointSummary("Get All Categories")]
        [ProducesResponseType(typeof(IEnumerable<CategoryResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<CategoryResponse>>> GetCategories()
        {
            var categoriesResponse = await _courseService.GetAllCategoriesAsync();

            if (!categoriesResponse.Any())
                return new ObjectResult(new ApiResponse(StatusCodes.Status204NoContent, "There are no Categories yet!"));

            return Ok(categoriesResponse);
        }

        [HttpGet("Levels")]
        [EndpointSummary("Get All Course Levels (Admin Only)")]
        [ProducesResponseType(typeof(IEnumerable<CategoryResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<CourseLevelResponse>> GetLevels()
        {
            var levelsResponse = _courseService.GetCourseLevels();

            return Ok(levelsResponse);
        }

        [HttpPost]
        [EndpointSummary("Create Course (Admin Only)")]
        [ProducesResponseType(typeof(ApiResponse),200)]
        public async Task<ActionResult> CreateCourse([FromForm] CreateCourseRequest courseRequest)
        {
            
            var result = await _courseService.CreateCourseAsync(courseRequest);

            if (result == 0)
                return BadRequest(new ApiResponse(400, "Failed to create the course"));

            return StatusCode(201, new ApiResponse(201, "Course created successfully"));
            
        }

        [HttpPut("{id}")]
        [EndpointSummary("Update Course (Admin Only)")]
        [ProducesResponseType(typeof(ApiResponse),200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<ActionResult<ApiResponse>> UpdateCourse(int id, [FromForm] UpdateCourseRequest courseRequest)
        {
            var result = await _courseService.UpdateCourseAsync(id, courseRequest);

            if (result == 0)
                return BadRequest(new ApiResponse(StatusCodes.Status400BadRequest, "Course Cannot be Ubdated"));

            return Ok(new ApiResponse(200, "Course updated successfully"));
        }


        [HttpDelete("{id}")]
        [EndpointSummary("Delete Course (Admin Only)")]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        [ProducesResponseType(typeof(ApiResponse),StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteCourse(int id)
        {
            var result = await _courseService.DeleteCourseAsync(id);
            if (result == 0)
                return BadRequest(new ApiResponse(StatusCodes.Status400BadRequest, "Course Cannot be Deleted"));
            return Ok(new ApiResponse(200, "Course deleted successfully"));
        }
    }
}
