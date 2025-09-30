using AutoMapper;
using Byway.Application.DTOs.Instructor;
using Byway.Application.Services;
using Byway.Application.Specifications.Instructor_Specs;
using Byway.CourseManagement.Algoriza.API.Errors;
using Byway.CourseManagement.Algoriza.API.Pagination;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Byway.CourseManagement.Algoriza.API.Controllers
{
    public class InstructorsController(InstructorService instructorService, IMapper mapper) : BaseApiController
    {
        private readonly InstructorService _instructorService = instructorService;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        //[ProducesResponseType(typeof(Pagination<InstructorForUserResponse>), 200)]
        //[ProducesResponseType(typeof(ApiResponse), 500)]
        public async Task<ActionResult<Pagination<InstructorResponse>>> GetAllInstructors([FromQuery] InstructorSpecParams specParams)
        {
            var (insResponse, count) = await _instructorService.GetAllInstructorsAsync(specParams);

            if (count == 0) return NoContent();

            var responseData = insResponse.Select(i => _mapper.Map<InstructorResponse>(i));

            return Ok(new Pagination<InstructorResponse>(specParams.PageIndex, specParams.PageSize, count, responseData));
        }
    }
}
