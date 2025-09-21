namespace Byway.CourseManagement.Algoriza.API.Errors
{
    public class ApiValidationResponse() : ApiResponse(400)
    {
        public IEnumerable<string> Errors { get; set; } = new List<String>();

    }
}
