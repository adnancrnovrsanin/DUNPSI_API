namespace Application.SoftwareProjects
{
    public class ProjectCreateDto
    {
        public Guid ClientId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DueDate { get; set; }
        public Guid AssignedProjectManager { get; set; }
    }
}