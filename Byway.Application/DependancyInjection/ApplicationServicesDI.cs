using Byway.Application.Contracts;
using Byway.Application.File_Service;
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
            services.AddScoped<IFileUploadService, FileUploadService>();
            services.AddScoped<ICourseService, CourseService>();

            return services;
        }
    }
}
