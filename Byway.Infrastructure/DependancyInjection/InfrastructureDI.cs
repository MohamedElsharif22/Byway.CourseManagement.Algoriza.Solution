using Byway.Application.Contracts.ExternalServices;
using Byway.Domain;
using Byway.Domain.Entities;
using Byway.Domain.Entities.Identity;
using Byway.Domain.Repositoies.Contract;
using Byway.Infrastructure._Data;
using Byway.Infrastructure.ExternalServices;
using Byway.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Byway.Infrastructure.DependancyInjection
{
    public static class InfrastructureDI
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

            });

            return services;
        }
        public static IServiceCollection AddDbContextServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Configure Context Services
            services.AddDbContext<BywayDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<BywayDbContext>();



            return services;
        }
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            // Register Repositories 
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddScoped<IInstructorRepository, InstructorRepository>();
            services.AddScoped<ICartRepository, CartRepository>();

            // Register External Services
            services.AddScoped<IGoogleAuthService, GoogleAuthService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IFileUploadService, FileUploadService>();
            services.AddScoped<IAuthService, AuthService>();


            return services;
        }
    }
}
