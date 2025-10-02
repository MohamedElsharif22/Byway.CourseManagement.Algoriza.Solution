using Byway.Application.Contracts;
using Byway.Application.Mapping;
using Byway.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
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
            services.AddScoped<IFileUploadService, FileUploadService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<CartService>();
            services.AddScoped<InstructorService>();
            services.AddScoped<AuthService>();
            services.AddAutoMapper(c => { } ,typeof(MappingProfiles).Assembly);
            return services;
        }
    }
}
