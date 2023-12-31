namespace Domain.ModelsDTOs
{
    public class DeveloperDto
    {
        public Guid Id { get; set; }
        public string AppUserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public int NumberOfActiveTasks { get; set; }
    }
}