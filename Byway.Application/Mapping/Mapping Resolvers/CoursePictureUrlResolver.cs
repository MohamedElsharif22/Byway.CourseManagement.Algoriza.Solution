using AutoMapper;
using Byway.Application.DTOs.Course;
using Byway.Domain.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Application.Mapping.Mapping_Resolvers
{
    internal class CoursePictureUrlResolver(IConfiguration configuration) : IValueResolver<Course, CourseResponse, string>
    {
        private readonly IConfiguration _configuration = configuration;

        public string Resolve(Course source, CourseResponse destination, string destMember, ResolutionContext context)
        {
            return source.CoverPictureUrl is null ? null! : $"{_configuration["BaseApiUrl"]}/{source.CoverPictureUrl}";
        }
    }
}
