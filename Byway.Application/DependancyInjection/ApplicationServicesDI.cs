using Byway.Application.Contracts;
using Byway.Application.Contracts.ExternalServices;
using Byway.Application.Mapping;
using Byway.Application.Services;
using Byway.Application.Services.ExternalServices;
using Byway.Domain.Entities.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Application.DependancyInjection
{
    public static class ApplicationServicesDI
    {
        public static IServiceCollection AddAuthenticationServices(this IServiceCollection services, IConfiguration _configuration)
        {

            // Adding Authintication Schema Bearer
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = _configuration["JWT:ValidIssuer"],
                    ValidateAudience = true,
                    ValidAudience = _configuration["JWT:ValidAudience"],
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:AuthKey"] ?? string.Empty)),
                    ValidateLifetime = true,
                    
                    ClockSkew = TimeSpan.Zero,
                };

            }).AddGoogle(options =>
            {
                options.ClientId = _configuration["Authentication:Google:ClientId"]!;
                options.ClientSecret = _configuration["Authentication:Google:ClientSecret"]!;
            }); 

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICheckoutService, CheckoutService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IFileUploadService, FileUploadService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<CartService>();
            services.AddScoped<IInstructorService, InstructorService>();
            services.AddScoped<AuthService>();
            services.AddScoped<IGoogleAuthService, GoogleAuthService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddAutoMapper(c => { } ,typeof(MappingProfiles).Assembly);

            return services;
        }
    }
}
