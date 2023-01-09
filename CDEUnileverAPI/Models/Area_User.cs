namespace CDEUnileverAPI.Models
{
    public class Area_User
    {
        public int Id { get; set; }
        public int AreaId { get; set; }
        public Area Area { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
