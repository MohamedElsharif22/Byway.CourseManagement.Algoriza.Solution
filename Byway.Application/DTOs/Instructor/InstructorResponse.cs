namespace Byway.Application.DTOs.Instructor
{

    public record JobTitleReponse
    {
        public string Title { get; set; }
        public int Value { get; set; }
    }

    public record InstructorResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string JopTitle { get; set; }
        public string? About { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public int CoursesCount { get; set; }
        public int TotalLectures { get; set; }
        public decimal AverageRating { get; set; }
        public int StudentsCount { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
