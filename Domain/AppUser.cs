using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ProfileImageUrl { get; set; }
        public IEnumerable<Message> MessagesSent { get; set; }
        public IEnumerable<Message> MessagesReceived { get; set; }
    }
}