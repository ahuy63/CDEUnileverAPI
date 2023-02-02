namespace CDEUnileverAPI.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int SenderId { get; set; }
        public User Sender { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    }
}
