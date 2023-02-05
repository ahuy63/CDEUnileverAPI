namespace CDEUnileverAPI.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Thumbnail { get; set; }
        public string Title { get; set; }
        public string Hypertext { get; set; }
        public string ShortDescription { get; set; }
        public int CreatedById { get; set; }
        public User CreatedBy { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public bool IsPublished { get; set; } = false;
        public bool Status { get; set; } = true;
    }
}
