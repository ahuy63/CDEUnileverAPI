namespace CDEUnileverAPI.Models
{
    public class Comment
    {
        public int id { get; set; }
        public int JobTaskId { get; set; }
        public JobTask JobTask { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Content { get; set; } = "No Comment";
        public double Rating { get; set; }
    }
}
