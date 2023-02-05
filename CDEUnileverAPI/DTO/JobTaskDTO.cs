using CDEUnileverAPI.Models;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace CDEUnileverAPI.DTO
{
    public class JobTaskDTO
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public int AssigneeId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int VisitPlanId { get; set; }
        [Required]
        public DateTime DateStart { get; set; }
        [Required]
        public DateTime DateEnd { get; set; }
        [Required]
        public int CreatedById { get; set; }
    }
    public class ShowJobTaskListDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AssigneeFullName { get; set; }
        public DateTime DateStart { get; set; }
        public string Status { get; set; }
    }
    public class ShowJobTaskDetailsDTO
    {
        public string Title { get; set; }
        public string Status { get; set; }
        public string AssigneeFullName { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string CreatedByFullName { get; set; }
        public string Description { get; set; }
        public float Rating { get; set; }
        public ICollection<ShowCommentListDTO> Comments { get; set; }
    }

}
