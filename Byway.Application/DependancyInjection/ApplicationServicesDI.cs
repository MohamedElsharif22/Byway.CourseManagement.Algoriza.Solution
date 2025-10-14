using Byway.Application.Contracts;
using Byway.Application.Contracts.ExternalServices;
using Byway.Application.Mapping;
using Byway.Application.Services;
using Byway.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Application.DependancyInjection
{
    public static class ApplicationServicesDI
    {
        

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICheckoutService, CheckoutService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<CartService>();
            services.AddScoped<IInstructorService, InstructorService>();
            services.AddAutoMapper(c => { } ,typeof(MappingProfiles).Assembly);

            return services;
        }
    }
}
