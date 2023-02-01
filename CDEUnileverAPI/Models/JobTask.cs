namespace CDEUnileverAPI.Models
{
    public class JobTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AssigneeId { get; set; }
        public User Assignee { get; set; }
        public int CreatedById { get; set; }
        public User CreatedBy { get; set; }
        public string Description { get; set; }
        public int VisitPlanId { get; set; }
        public VisitPlan VisitPlan { get; set; }
        public bool Status { get; set; } = true;
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public double Rating { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
