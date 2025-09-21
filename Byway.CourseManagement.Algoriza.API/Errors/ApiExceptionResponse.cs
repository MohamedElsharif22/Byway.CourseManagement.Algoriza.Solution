namespace Byway.CourseManagement.Algoriza.API.Errors
{
    public class ApiExceptionResponse(int statusCode, string message, string description) : ApiResponse(statusCode, message)
    {
        public string Description { get; } = description;
    }
}
