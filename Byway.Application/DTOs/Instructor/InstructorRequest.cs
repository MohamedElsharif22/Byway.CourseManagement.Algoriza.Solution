using Byway.Domain.Entities.enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Application.DTOs.Instructor
{
    public record InstructorRequest
    {
        [Required]
        [MinLength(5)]
        public string Name { get; set; }
        [Required]
        [Range(1,12)]
        public int JopTitle { get; set; }
        [Required]
        [MinLength(10)]
        public string? About { get; set; }
        [Required]
        public IFormFile ProfilePicture { get; set; }

    }
}
