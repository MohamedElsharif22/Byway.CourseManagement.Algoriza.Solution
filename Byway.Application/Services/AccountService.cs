using Byway.Application.Contracts;
using Byway.Application.Contracts.ExternalServices;
using Byway.Application.DTOs.Account;
using Byway.Application.DTOs.Course;
using Byway.Application.DTOs.Email;
using Byway.Application.Mapping;
using Byway.Domain;
using Byway.Domain.Entities.Checkout;
using Byway.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Application.Services
{
    public class AccountService(UserManager<ApplicationUser> userManager,
                                SignInManager<ApplicationUser> signInManager,
                                IAuthService authService,
                                IGoogleAuthService googleAuthService,
                                IEmailService emailService,
                                ILogger<AccountService> logger) : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly SignInManager<ApplicationUser> _signInManager = signInManager;
        private readonly IAuthService _authService = authService;
        private readonly IGoogleAuthService _googleAuthService = googleAuthService;
        private readonly IEmailService _emailService = emailService;
        private readonly ILogger<AccountService> _logger = logger;

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

            var emailRequset = new EmailRequest()
            {
                ToEmail = user.Email,
                ToName = user.UserName??"",
                Subject = "Login Success",
                Body = "You succesfully Logged to Byway!"
            };

            await _emailService.SendEmailAsync(emailRequset);

            return (user.ToUserResponse(token), "Successful Login.");

        }

        public async Task<(UserResponse?, IEnumerable<string>?)> RegisterAsync(RegisterRequest request)
        {
            var appUser = new ApplicationUser
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.Email.Substring(0, request.Email.IndexOf("@")),
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
            var emailRequset = new EmailRequest()
            {
                ToEmail = appUser.Email,
                ToName = $"{appUser.LastName} {appUser.LastName}",
                Subject = "Registeration success",
                Body = $"{appUser.FirstName} Thank You for Regestiering to Byway!"
            };

            await _emailService.SendEmailAsync(emailRequset);

            return (appUser.ToUserResponse(token), errors);
        }

        public async Task<(UserResponse?, string?)> GoogleAuthAsync(GoogleAuthRequest request)
        {
            // Validate Google token
            var googleUser = await _googleAuthService.ValidateGoogleTokenAsync(request.IdToken);

            
            if (googleUser == null)
            {
                return (null, "Invalid Google token");
            }

            if (!googleUser.EmailVerified)
            {
                return (null, "Google email is not verified");
            }

            // Check if user already exists
            var existingUser = await _userManager.FindByEmailAsync(googleUser.Email);

            ApplicationUser user;

            if (existingUser != null)
            {
                // User exists - Login
                user = existingUser;

                // Check if Google login is already linked
                var logins = await _userManager.GetLoginsAsync(user);
                var googleLogin = logins.FirstOrDefault(l => l.LoginProvider == "Google");

                if (googleLogin == null)
                {
                    // Link Google account to existing user
                    var addLoginResult = await _userManager.AddLoginAsync(user,
                        new UserLoginInfo("Google", googleUser.GoogleId, "Google"));

                    if (!addLoginResult.Succeeded)
                    {
                        _logger.LogError("Failed to link Google account for user {Email}", googleUser.Email);
                    }
                }
            }
            else
            {
                // User doesn't exist - Register
                user = new ApplicationUser
                {
                    FirstName = googleUser.FirstName,
                    LastName = googleUser.LastName,
                    Email = googleUser.Email,
                    UserName = googleUser.Email,
                    EmailConfirmed = true // Google email is already verified
                };

                // Create user without password (external login)
                var createResult = await _userManager.CreateAsync(user);

                if (!createResult.Succeeded)
                {
                    var errors = string.Join(", ", createResult.Errors.Select(e => e.Description));
                    return (null, $"Failed to create user: {errors}");
                }

                // Add external login info
                var addLoginResult = await _userManager.AddLoginAsync(user,
                    new UserLoginInfo("Google", googleUser.GoogleId, "Google"));

                if (!addLoginResult.Succeeded)
                {
                    _logger.LogError("Failed to add Google login for new user {Email}", googleUser.Email);
                }

                // Assign default role
                var roleResult = await _userManager.AddToRoleAsync(user, "User");
                if (!roleResult.Succeeded)
                {
                    _logger.LogError("Failed to assign role to user {Email}", googleUser.Email);
                }
            }

            // Generate JWT token
            var token = await _authService.CreateTokenAsync(user, _userManager);

            var emailRequset = new EmailRequest()
            {
                ToEmail = user.Email,
                ToName = user.UserName ?? "",
                Subject = "Login Success",
                Body = "You succesfully Signed in to Byway!"
            };

            await _emailService.SendEmailAsync(emailRequset);

            return (user.ToUserResponse(token), "Successful Google authentication.");
        }

    }
}
