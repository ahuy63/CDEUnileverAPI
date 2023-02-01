using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.DTO
{
    public class VisitPlanDTO
    {
        public string Name { get; set; }
        public IEnumerable<DateTime> Dates { get; set; }
        public string Time { get; set; }
        public int DistributorId { get; set; }
        public string Purpose { get; set; }
        public int GuestId { get; set; }
    }
    public class ShowVisitPlanListDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
    }

    public class VisitPlanDetailDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Purpose { get; set; }
        public DateTime Date { get; set; }  
        public ICollection<ShowJobTaskListDTO> Tasks { get; set; }
    }
}
