using AutoMapper;
using Byway.Application.Contracts;
using Byway.Application.DTOs;
using Byway.Application.DTOs.Instructor;
using Byway.Application.Services;
using Byway.Application.Specifications.Instructor_Specs;
using Byway.CourseManagement.Algoriza.API.Errors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Byway.CourseManagement.Algoriza.API.Controllers
{
    [Authorize(Roles = "Admin")]
    public class InstructorsController(IInstructorService instructorService) : BaseApiController
    {
        private readonly IInstructorService _instructorService = instructorService;

        [AllowAnonymous]
        [EndpointSummary("Get All Instructors!")]
        [ProducesResponseType(typeof(Pagination<InstructorResponse>), 200)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status204NoContent)]
        [HttpGet]
        public async Task<ActionResult<Pagination<InstructorResponse>>> GetAllInstructors([FromQuery] InstructorSpecParams specParams)
        {
            var page = await _instructorService.GetAllInstructorsAsync(specParams);

            if (page.Count == 0) return StatusCode(StatusCodes.Status204NoContent, new ApiResponse(StatusCodes.Status204NoContent, "No Content!"));

            return Ok(page);
        }

        [AllowAnonymous]
        [EndpointSummary("Get By ID!")]
        [ProducesResponseType(typeof(InstructorResponse), 200)]
        [ProducesResponseType(typeof(ApiResponse), 404)]
        [HttpGet("{id}")]
        public async Task<ActionResult<InstructorResponse>> GetById(int id)
        {
            var instructor = await _instructorService.GetInstructorByIdAsync(id);

            if (instructor is null)
                return NotFound(new ApiResponse(StatusCodes.Status400BadRequest));

            return Ok(instructor);
        }


        [EndpointDescription("Get All JobTitles")]
        [EndpointSummary("Get All JobTitles")]
        [HttpGet("JobTitles")]
        public ActionResult<IEnumerable<JobTitleReponse>>GetJopTitles()
        {
            return Ok(_instructorService.GetAllJobTitles());
        }

        
        [EndpointDescription("Add New Instructor")]
        [EndpointSummary("Add New Instructor (Admin Only)")]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        [HttpPost]
        public async Task<ActionResult<ApiResponse>>CreateInstructor([FromForm] CreateInstructorRequest instructorRequest)
        {
            var (isCreated, message) = await _instructorService.CreateInstructorAsync(instructorRequest);

            if (!isCreated) 
                return BadRequest(new ApiResponse(400, message ?? "Unable to add instructor!"));

            return Ok(new ApiResponse(200,message));
        }

        [EndpointDescription("Update Instructor")]
        [EndpointSummary("Update Instructor (Admin Only)")]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse>>UpdateInstructor(int id, [FromForm] UpdateInstructorRequest instructorRequest)
        {
            var (isUpdated, message) = await _instructorService.UpdateInstructorAsync(id, instructorRequest);

            if (!isUpdated) 
                return BadRequest(new ApiResponse(400, message ?? "Unable to add instructor!"));

            return Ok(new ApiResponse(200,message));
        }


        [EndpointDescription("Update Instructor")]
        [EndpointSummary("Delete Instructor (Admin Only)")]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse>>DeleteInstructor(int id)
        {
            var (isDeleted, message) = await _instructorService.DeleteInstructorAsync(id);

            if (!isDeleted) 
                return BadRequest(new ApiResponse(400, message ?? "Unable to add instructor!"));

            return Ok(new ApiResponse(200,message));
        }



    }
}
