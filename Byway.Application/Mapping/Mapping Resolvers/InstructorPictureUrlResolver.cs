using AutoMapper;
using Byway.Application.DTOs.Course;
using Byway.Application.DTOs.Instructor;
using Byway.Domain.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Application.Mapping.Mapping_Resolvers
{
    internal class InstructorPictureUrlResolver(IConfiguration configuration) : IValueResolver<Instructor, InstructorResponse, string>
    {
        private readonly IConfiguration _configuration = configuration;

        public string Resolve(Instructor source, InstructorResponse destination, string destMember, ResolutionContext context)
        {
            return $"{_configuration["BaseApiUrl"]}/{source.ProfilePictureUrl}";
        }
    }
}
