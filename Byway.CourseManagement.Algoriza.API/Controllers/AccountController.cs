using Byway.Application.Contracts;
using Byway.Application.DTOs.Account;
using Byway.Application.Mapping;
using Byway.Application.Services;
using Byway.CourseManagement.Algoriza.API.Errors;
using Byway.Domain.Entities.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Byway.CourseManagement.Algoriza.API.Controllers
{
    public class AccountController(IAccountService accountService,
                                   UserManager<ApplicationUser> userManager,
                                   AuthService authService) : BaseApiController
    {
        private readonly IAccountService _accountService = accountService;
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly AuthService _authService = authService;

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

        [EndpointSummary("Login or register Account using google!")]
        [ProducesResponseType(typeof(UserResponse),200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        [HttpPost("google-auth")]
        public async Task<ActionResult<UserResponse>> LoginOrRegisterWithGoogle(GoogleAuthRequest request)
        {

            var (userResponse, error) = await _accountService.GoogleAuthAsync(request);
            if (userResponse is null)
                return BadRequest(new ApiResponse(400, error??"Invalid google token"));

            return Ok(userResponse);
        }


        [EndpointSummary("Get Current user")]
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserResponse>> GetCurrentUser()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);

            if (string.IsNullOrWhiteSpace(email)) return NotFound(new ApiResponse(404));

            var user = await _userManager.FindByEmailAsync(email);

            if (user is null) return NotFound(new ApiResponse(404));

            var token = await _authService.CreateTokenAsync(user, _userManager);

            return Ok(user.ToUserResponse(token));
        }





    }
}
