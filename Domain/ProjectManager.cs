namespace Domain
{
    public class ProjectManager
    {
        public Guid Id { get; set; }
        public string AppUserId { get; set; }
        public string CertificateUrl { get; set; }
        public int YearsOfExperience { get; set; }
        public AppUser AppUser { get; set; }
        public IEnumerable<Team> ManagedTeams { get; set; }
        public IEnumerable<Rating> GivenRatings { get; set; }
    }
}