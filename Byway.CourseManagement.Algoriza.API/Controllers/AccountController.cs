using Byway.Application.Contracts;
using Byway.Application.DTOs.Account;
using Byway.Application.Services;
using Byway.CourseManagement.Algoriza.API.Errors;
using Byway.Domain.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Byway.CourseManagement.Algoriza.API.Controllers
{
    public class AccountController(IAccountService accountService) : BaseApiController
    {
        private readonly IAccountService _accountService = accountService;

        [HttpPost("register")]
        [EndpointSummary("Register New Account!")]
        [ProducesResponseType(typeof(UserResponse),200)]
        [ProducesResponseType(typeof(ApiValidationErrorResponse), 400)]
        public async Task<ActionResult<UserResponse>> Register(RegisterRequest request)
        {

            var (userResponse, errors) = await _accountService.RegisterAsync(request);
            if (userResponse is null)
                return BadRequest(new ApiValidationErrorResponse { Errors = errors!});

            return Ok(userResponse);
        }

        [HttpPost("login")]
        [EndpointSummary("Login Account!")]
        [ProducesResponseType(typeof(UserResponse),200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<ActionResult<UserResponse>> Login(LoginRequest request)
        {

            var (userResponse, error) = await _accountService.LoginAsync(request);
            if (userResponse is null)
                return BadRequest(new ApiResponse(400, error??"Invalid Email or Password!"));

            return Ok(userResponse);
        }







    }
}
