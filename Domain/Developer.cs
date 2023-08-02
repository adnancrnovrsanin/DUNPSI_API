namespace Domain
{
    public class Developer
    {
        public Guid Id { get; set; }
        public string AppUserId { get; set; }
        public string Position { get; set; }
        public int NumberOfActiveTasks { get; set; }
        public AppUser AppUser { get; set; }
        public IEnumerable<RequirementManagement> AssignedRequirements { get; set; }
        public IEnumerable<Rating> ReceivedRatings { get; set; }
        public IEnumerable<DeveloperTeamPlacement> AssignedTeams { get; set; }
    }
}