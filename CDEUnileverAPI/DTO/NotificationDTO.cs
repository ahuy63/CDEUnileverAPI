using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.DTO
{
    public class NotificationDTO
    {
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int SenderId { get; set; }
    }

    public class ShowNotiListDTO
    {
        public string SenderFullName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
