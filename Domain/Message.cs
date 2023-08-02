namespace Domain
{
    public class Message
    {
        public Guid Id { get; set; }
        public string SenderId { get; set; }
        public string RecipientId { get; set; }
        public string Content { get; set; }
        public DateTime DateTimeSent { get; set; } = DateTime.UtcNow;
        public DateTime? DateTimeRead { get; set; }
        public AppUser Sender { get; set; }
        public AppUser Recipient { get; set; }
    }
}