namespace Domain
{
    public class SoftwareProject
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool Finished { get; set; }
        public Guid AssignedTeamId { get; set; }
        public Team AssignedTeam { get; set; }
        public SoftwareCompany Client { get; set; }
        public ICollection<ProjectPhase> Phases { get; set; }
        public ICollection<Rating> DeveloperRatings { get; set; }
    }
}