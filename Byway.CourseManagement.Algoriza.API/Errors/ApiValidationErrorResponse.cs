﻿namespace Byway.CourseManagement.Algoriza.API.Errors
{
    public class ApiValidationErrorResponse() : ApiResponse(400)
    {
        public IEnumerable<string> Errors { get; set; } = new List<String>();

    }
}
