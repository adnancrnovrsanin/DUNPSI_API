namespace Domain.ModelsDTOs
{
    public class TeamDto
    {
        public Guid Id { get; set; }
        public Guid ProjectManagerId { get; set; }
        public Guid ProjectId { get; set; }
        public IEnumerable<DeveloperDto> Developers { get; set; }
    }
}