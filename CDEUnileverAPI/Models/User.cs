using System.ComponentModel.DataAnnotations;

namespace CDEUnileverAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int? TitleId { get; set; }
        public Title? Title { get; set; }
        public int? AreaId { get; set; }
        public Area? Area { get; set; }
        public bool Status { get; set; }
        public int? ReporterId { get; set; }
        public User? Reporter { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Avatar { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    }
}
