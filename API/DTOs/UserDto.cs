namespace API.DTOs
{
    public class UserDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string? ProfileImageUrl { get; set; }
        public string Token { get; set; }
    }
}