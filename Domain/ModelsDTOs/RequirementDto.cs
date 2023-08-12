namespace Domain.ModelsDTOs
{
    public class RequirementDto
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Guid PhaseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public RequirementApproveStatus Status { get; set; }
        public IEnumerable<DeveloperDto> AssignedDevelopers { get; set; }
    }
}