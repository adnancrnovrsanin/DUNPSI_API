namespace Domain
{
    public class InitialProjectRequest
    {
        public Guid Id { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public DateTime DueDate { get; set; }
        public bool Rejected { get; set; }
        public Guid ClientId { get; set; }
        public SoftwareCompany Client { get; set; }
    }
}