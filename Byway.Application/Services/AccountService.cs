using Byway.Application.Contracts;
using Byway.Application.DTOs.Account;
using Byway.Application.DTOs.Course;
using Byway.Application.Mapping;
using Byway.Domain;
using Byway.Domain.Entities.Checkout;
using Byway.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Application.Services
{
    public class AccountService(UserManager<ApplicationUser> userManager,
                                SignInManager<ApplicationUser> signInManager,
                                AuthService authService,
                                ICourseService courseService,
                                IUnitOfWork unitOfWork) : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly SignInManager<ApplicationUser> _signInManager = signInManager;
        private readonly AuthService _authService = authService;
        private readonly ICourseService _courseService = courseService;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<(UserResponse?, string?)> LoginAsync(LoginRequest request)
        {

            string error;
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null)
            {
                error = "Email is Incorrect!";
                return(null, error);
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if(!result.Succeeded)
            {
                error = "Password is Incorrect!";
                return (null, error);
            }

            var token = await _authService.CreateTokenAsync(user, _userManager);

            return (user.ToUserResponse(token), "Successful Login.");

        }

        public async Task<(UserResponse?, IEnumerable<string>?)> RegisterAsync(RegisterRequest request)
        {
            var appUser = new ApplicationUser
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.Phone
            };

            var result = await _userManager.CreateAsync(appUser, request.Password);

            IEnumerable<string> errors = [];
            if (!result.Succeeded)
            {
                errors = result.Errors.Select(e => e.Description);
                return (null, errors);
            }

            var asignedtoRole = await _userManager.AddToRoleAsync(appUser, "User");
            if (!asignedtoRole.Succeeded)
            {
                asignedtoRole.Errors.Select(e => errors.Append(e.Description));

                return(null, errors);
            }

            var token = await _authService.CreateTokenAsync(appUser, _userManager);

            return (appUser.ToUserResponse(token), errors);
        }

    }
}
