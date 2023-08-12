namespace Domain.ModelsDTOs
{
    public class InitialProjectRequestDto
    {
        public Guid Id { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public string DueDate { get; set; }
        public bool Rejected { get; set; }
        public Guid ClientId { get; set; }
    }
}