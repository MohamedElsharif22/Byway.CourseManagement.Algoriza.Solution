namespace Byway.Application.DTOs.Account
{
    public record UserResponse
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
