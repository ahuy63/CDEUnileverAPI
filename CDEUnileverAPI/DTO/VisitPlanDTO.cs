using CDEUnileverAPI.Models;
using Microsoft.Build.Framework;

namespace CDEUnileverAPI.DTO
{
    public class VisitPlanDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [ValidateYears]
        public IEnumerable<DateTime> Dates { get; set; }
        [Required]
        public string Time { get; set; }
        [Required]
        public int DistributorId { get; set; }
        [Required]
        public string Purpose { get; set; }
        public int? GuestId { get; set; }
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
